
var LoginGps = function (document, window, $) {

    //TIPO GLOBAIS
    var baseUrl = 'http://' + window.location.hostname;

    if (window.location.hostname.includes('localhost')) {
        baseUrl = 'http://' + window.location.hostname + '/' + window.location.pathname.split('/')[1];
    }
    var logado = new Object();
    return (
        {
            formulario: function (res) {
                $('#FindAtual').empty();
                $('.venda').empty();
                
                var vendidoCount = 0;
            

                for (var i = 0; i < res.veiculos.length; i++) {
                    var veic = res.veiculos[i];
                    var check = "";
                    if (veic.vendido == true) {
                        vendidoCount += 1;
                         check = "checked";
                    }
                    var tbl = '<table>';
                    tbl += '<tr> <td><label for="id"></label>Id</td>';
                    tbl += ' <td><input style="text-align:center" disabled type="text"  value=' + veic.id + ' name=' + veic.id + '/></td>';
                    tbl += '<td></td></tr>';

                    tbl += '<tr> <td><label for="veiculo"></label>Veiculo</td>';
                    tbl += ' <td><input style="text-align:center" disabled type="text" class="veiculo" value=' + veic.veiculo + ' name=' + veic.veiculo + '/></td>';
                    tbl += '<td></td></tr>';

                    tbl += '<tr> <td><label for="marca"></label>Marca</td>';
                    tbl += ' <td><input  style="text-align:center" disabled type="text" class="marca" value=' + veic.marca + ' name=' + veic.marca + '/></td>';
                    tbl += '<td></td></tr>';

                    tbl += '<tr> <td><label for="ano"></label>Ano</td>';
                    tbl += ' <td><input data-slots="y" placeholder="yyyy " style="text-align:center" disabled type="text" class="ano" value=' + veic.ano + ' name=' + veic.ano + ' /></td>';
                    tbl += '<td></td></tr>';

                    tbl += '<tr> <td><label for="cor"></label>Cor</td>';
                    tbl += ' <td><input style="text-align:center" disabled type="text" class="cor" value=' + veic.cor + ' name=' + veic.cor + '/></td>';
                    tbl += '<td></td></tr>';

                    tbl += '<tr> <td><label for="descr"></label>Descrição</td>';
                    tbl += ' <td><input  style="text-align:center" disabled type="text" class="descr" value=' + veic.descricao + ' name=' + veic.descricao + '/></td>';
                    tbl += '<td></td></tr>';

                    tbl += '<tr> <td><label for="veindido"></label>Vendido</td>';
                    tbl += ' <td><input  style="text-align:center" disabled type="checkbox" ' + check+' class="vendido" value=' + veic.vendido + ' name=' + veic.vendido + '/></td>';
                    tbl += '<td></td></tr>';


                    tbl += '<tr> <td></td>';
                    tbl += ' <td style="padding: 5px 0px;"><button  style=" display: none;"  class="float btn btn-success saveedit" onclick="LoginGps.saveedit(\'' + veic.id + '\')" type="submit">ok</button>';
                    tbl += ' <button style=" display: none;" class="float btn btn-secondary canceedit" onclick="LoginGps.canceeditbtn(\'' + veic.id + '\')" type="submit">cancelar</button>';
                    tbl += ' <button class="float btn btn-warning editform" onclick="LoginGps.editarbt(\'' + veic.id + '\')" >editar</button>';
                    tbl += ' <button  class="float btn btn-danger btn-deletar" onclick="LoginGps.deletar(\'' + veic.id + '\')"  >Delete</button></td>';
                    tbl += '</tr>';
                    $('#FindAtual').append('<div id=' + veic.id + '>' + tbl + ' </div>');

                }

                var totalvendido = '<div class="venda" style="margin-top:-220px;margin-left:262px">  ';
                totalvendido += '<span>'
                totalvendido += 'Total de carros vendidos é : ' + vendidoCount
                totalvendido += '</span>'
                totalvendido += '</div>'

                $('#show-result').append(totalvendido);

                $(".btn-deletar").alert(5);
            },

            get_para: function () {
                $("#cadastrar").css("display", "none");
                $("#findparamter").css("display", "block");
            },

            cadastroveiculo: function () {
                $("#findparamter").css("display", "none");
                $("#show-result").css("display", "none");

                $("#cadastrar").css("display", "block");
            },

            canceeditbtn: function (id) {
                $($("#" + id)[0]).find(".veiculo").attr("disabled", true);
                $($("#" + id)[0]).find(".marca").attr("disabled", true);
                $($("#" + id)[0]).find(".ano").attr("disabled", true);
                $($("#" + id)[0]).find(".cor").attr("disabled", true);
                $($("#" + id)[0]).find(".descr").attr("disabled", true);
                $($("#" + id)[0]).find(".vendido").attr("disabled", true);

                $($("#" + id)[0]).find(".saveedit").css("display", "none")
                $($("#" + id)[0]).find(".canceedit").css("display", "none")

                $($("#" + id)[0]).find(".editform").css("display", "inherit")
                $($("#" + id)[0]).find(".btn-deletar").css("display", "inherit")
            },

            editarbt: function (id) {


                $($("#" + id)[0]).find(".veiculo").attr("disabled", false);
                $($("#" + id)[0]).find(".marca").attr("disabled", false);
                $($("#" + id)[0]).find(".ano").attr("disabled", false);
                $($("#" + id)[0]).find(".cor").attr("disabled", false);
                $($("#" + id)[0]).find(".descr").attr("disabled", false);
                $($("#" + id)[0]).find(".vendido").attr("disabled", false);

                $($("#" + id)[0]).find(".saveedit").css("display", "inherit")
                $($("#" + id)[0]).find(".canceedit").css("display", "inherit")

                $($("#" + id)[0]).find(".editform").css("display", "none")
                $($("#" + id)[0]).find(".btn-deletar").css("display", "none")
            },

            saveedit: function (id) {

                var veiculos = {
                    'id': id,
                    'veiculo': $($("#" + id)[0]).find(".veiculo").val(),
                    'marca': $($("#" + id)[0]).find(".marca").val(),
                    'ano': $($("#" + id)[0]).find(".ano").val(),
                    'cor': $($("#" + id)[0]).find(".cor").val(),
                    'descricao': $($("#" + id)[0]).find(".descr").val(),
                    'vendido': $($("#" + id)[0]).find(".vendido").val(),
                };
                
                var item = JSON.stringify(veiculos);

                url = '../Login/UpdateVeiculo'
                $(".btn").attr("disabled", true);
                $.ajax({
                    type: "PUT",
                    url: url,
                    cache: false,
                    async: true,
                    data: {
                        user: item
                    },
                    success: function (res) {
                        $(".btn").attr("disabled", false);
                        if (res) {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Sucesso ao atualizar Veiculo',
                                timer: 2000,
                                showConfirmButton: false,
                            })
                        } else {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Erro ao ataulizae veiculo',
                                timer: 2000,
                                showConfirmButton: false,
                            })
                        }
                    },
                    error: function (res) {

                    }
                });

                LoginGps.canceeditbtn(id);
            },


            get_All: function () {

                $("#show-result").css("display", "block");
                $("#cadastrar").css("display", "none");

                var cnpj = $("#txtBusca").val();
                var url = "../Login/GetAll";
                $(".btn").attr("disabled", true);
                $.ajax({
                    type: "GET",
                    url: url,
                    cache: false,
                    async: true,
                    data: {
                    },
                    success: function (res) {

                        $(".btn").attr("disabled", false);
                        if (res != "Error") {

                            LoginGps.formulario(res);
                        } else {

                            Swal.fire({
                                icon: 'warning',
                                title: 'Erro ao consultar lista',
                                timer: 2000,
                                showConfirmButton: false,
                            })
                        }
                    },
                    error: function (res) {
                        $(".btn").attr("disabled", false);
                    }
                });


            },         

            deletar: function (id) {
                var cnpj = id;                
                var url = "../Login/Delete";
                $(".btn").attr("disabled", true);
                
                $.ajax({
                    type: "Delete",
                    url: url,
                    cache: false,
                    async: true,
                    data: {
                        user: cnpj
                    },
                    success: function (res) {
                        $(".btn").attr("disabled", false);
                        if (res != "Error") {

                            Swal.fire({
                                icon: 'warning',
                                title: 'Sucesso ao excluir veiculos',
                                timer: 2000,
                                showConfirmButton: false
                            })

                        } else {

                            Swal.fire({
                                icon: 'warning',
                                title: 'Erro ao excluir veiculos',
                                timer: 2000,
                                showConfirmButton: false
                            })
                        }
                    },
                    error: function (res) {
                        $(".btn").attr("disabled", false);
                    }
                });



            },

            get_id: function () {

                var cnpj = $("#txtBusca").val();
                var url = "../Login/GetId";
                $(".btn").attr("disabled", true);
                
                $.ajax({
                    type: "GET",
                    url: url,
                    cache: false,
                    async: true,
                    data: {
                        user: cnpj
                    },
                    success: function (res) {
                        $(".btn").attr("disabled", false);
                        if (res != "Error") {

                            $('#FindAtual').empty();
                            $('.venda').empty();
                            var check = "";
                            var veic = res;
                            if (veic.vendido ) {
                                check = "checked";
                            }

                            var tbl = '<table>';
                            tbl += '<tr> <td><label for="veiculo"></label>Veiculo</td>';
                            tbl += ' <td><input disabled type="text" class="veiculos" value=' + veic.veiculo + ' name=' + veic.veiculo + '/></td>';
                            tbl += '<td></td></tr>';

                            tbl += '<tr> <td><label for="marca"></label>Marca</td>';
                            tbl += ' <td><input disabled type="text" class="marca" value=' + veic.marca + ' name=' + veic.marca + '/></td>';
                            tbl += '<td></td></tr>';

                            tbl += '<tr> <td><label for="ano"></label>Ano</td>';
                            tbl += ' <td><input data-slots="y" placeholder="yyyy " style="text-align:center" disabled type="text" class="ano" value=' + veic.ano + ' name=' + veic.ano + ' /></td>';
                            tbl += '<td></td></tr>';

                            tbl += '<tr> <td><label for="cor"></label>Cor</td>';
                            tbl += ' <td><input disabled type="text" class="cor" value=' + veic.cor + ' name=' + veic.cor + '/></td>';
                            tbl += '<td></td></tr>';

                            tbl += '<tr> <td><label for="descr"></label>Descrição</td>';
                            tbl += ' <td><input  disabled type="text" class="descr" value=' + veic.descricao + ' name=' + veic.descricao + '/></td>';
                            tbl += '<td></td></tr>';

                            tbl += '<tr> <td><label for="veindido"></label>Vendido</td>';
                            tbl += ' <td><input  disabled type="checkbox" class="vendido" ' + check +'   value=' + veic.vendido + ' name=' + veic.vendido + '/></td>';
                            tbl += '<td></td></tr>';


                            tbl += '<tr> <td></td>';
                            tbl += ' <td style="padding: 5px 0px;"><button  style=" display: none;"  class="float btn btn-success saveedit" onclick="LoginGps.save(\'' + veic.id + '\')" type="submit">ok</button>';
                            tbl += ' <button style=" display: none;" class="float btn btn-secondary canceedit" onclick="LoginGps.canceeditbtn(\'' + veic.id + '\')" type="submit">cancelar</button>';
                            tbl += ' <button class="float btn btn-warning editform" onclick="LoginGps.editarbt(\'' + veic.id + '\')" >editar</button>';
                            tbl += ' <button  class="float btn btn-danger btn-deletar" onclick="LoginGps.deletar(\'' + veic.id + '\')"  >Delete</button></td>';
                            tbl += '</tr>';
                            $('#FindAtual').append('<div id=' + veic.id + '>' + tbl + ' </div>');


                        } else {

                            Swal.fire({
                                icon: 'warning',
                                title: 'Erro ao consultar veiculo',
                                timer: 2000,
                                showConfirmButton: false,
                            })
                        }
                    },
                    error: function (res) {
                        $(".btn").attr("disabled", false);
                    }
                });


            },

            save: function () {
                
                var veiculos = {
                    'veiculo' : $("#tb-cadas").find("#veiculo").val(),
                    'marca': $("#tb-cadas").find("#marca").val(),
                    'ano' : $("#tb-cadas").find("#ano").val(),
                    'cor': $("#tb-cadas").find("#cor").val(),
                    'descricao' : $("#tb-cadas").find("#desc").val(),
                };
                var item = JSON.stringify(veiculos);

                
                url = '../Login/Cadastar'
                $(".btn").attr("disabled", true);
                $.ajax({
                    type: "POST",
                    url: url,
                    cache: false,
                    async: true,
                    data: {                        
                        user: item
                    },
                    success: function (res) {
                        $(".btn").attr("disabled", false);
                        if (res) {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Sucesso ao gravar Veiculo',
                                timer: 2000,
                                showConfirmButton: false,
                            })
                        } else {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Erro ao save carro',
                                timer: 2000,
                                showConfirmButton: false,
                            })
                        }
                    },
                    error: function (res) {

                    }
                });
            },

            findparmiter: function () {

                var marca = $("#tb-find-para").find("#marca").val();
                var cor = $("#tb-find-para").find("#ano").val();
                var ano = $("#tb-find-para").find("#cor").val();

                debugger
                url = '../Login/FindPatamiter'
                $(".btn").attr("disabled", true);
                $.ajax({
                    type: "GET",
                    url: url,
                    cache: false,
                    async: true,
                    data: {
                        marca: marca,
                        cor: cor,
                        ano: ano
                    },
                    success: function (res) {
                        $(".btn").attr("disabled", false);
                        if (res != "Error") {
                            LoginGps.formulario(res);
                        } else {

                            Swal.fire({
                                icon: 'warning',
                                title: 'Erro ao consultar veiculos',
                                timer: 2000,
                                showConfirmButton: false,

                            })
                        }

                    },
                    error: function (res) {

                    }
                });
            },

  

            erroAcesso: function () {
                window.location = baseUrl + '/Error/NotFound';
            }

        });
}(document, window, $);
