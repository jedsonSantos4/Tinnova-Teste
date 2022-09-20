
var LoginGps = function (document, window, $) {

    //TIPO GLOBAIS
    var baseUrl = 'http://' + window.location.hostname;

    if (window.location.hostname.includes('localhost')) {
        baseUrl = 'http://' + window.location.hostname + '/' + window.location.pathname.split('/')[1];
    }
    var logado = new Object();
    return (
        {
            login: function (psw, user) {

                var LogarModel = new Object();
                LogarModel.User = user;
                LogarModel.Password = psw;
                var jsonText = JSON.stringify(LogarModel);

                var url = "../Login/Logar";

                $.ajax({
                    type: "GET",
                    url: url,
                    cache: false,
                    async: true,
                    data: {
                        user: jsonText
                    },
                    success: function (res) {
                        $(".btn").attr("disabled", false);
                        if (res != "Error") {
                            logado = res;

                            $(".login").css("display", "none");
                            $(".consulta").css("display", "block");

                            LoginGps.get_cnpj_save();

                        } else {

                            Swal.fire({
                                icon: 'warning',
                                title: 'Erro ao logar',
                                timer: 2000,
                                showConfirmButton: false,

                            })
                        }
                    },
                    error: function (res) {

                    }
                });

            },

            logar: function () {
                
                var psw = $("#user_pswd").val();
                var user = $("#user_").val();

                if ((psw == undefined || psw == "") && (user == undefined || user == "")) {
                    $("#user_pswd").empty();
                    $("#user_").empty();

                    Swal.fire({
                        icon: 'warning',
                        title: 'CPF/Senha preenchencido errado',
                        timer: 2000,
                        showConfirmButton: false,
                    });
                    $(".btn").attr("disabled", false);
                } else {
                    $(".btn").attr("disabled", true);
                    LoginGps.login(psw, user);
                }
            },

            register: function(){
                $(".sign").css("display", "none");
                $(".register").css("display", "block");

            },
            save: function () {

                var psw = $("#register_psw").val();
                var pswv = $("#register_pswv").val();
                var user = $("#register_").val();
                var nome = $("#register_nome").val();
                
                if ((psw == undefined || psw == "") && (user == undefined || user == "") || (nome == undefined || nome == "") ) {
                    $("#register_psw").empty();
                    $("#register_").empty();


                    Swal.fire({
                        icon: 'warning',
                        title: 'Nome/Email/Senha preenchencido errado',
                        timer: 2000,
                        showConfirmButton: false,

                    })
                    return false;
                }
                if (psw != pswv || (pswv == undefined || pswv == "")) {
                    $("#register_psw").empty();
                    $("#register_pswv").empty();
                    Swal.fire({
                        icon: 'warning',
                        title: 'Senha Diferentes',
                        timer: 2000,
                        showConfirmButton: false,

                    })
                    return false;
                }
                else {
                    var cadastro = new Object();                    
                    cadastro.email = user;
                    cadastro.Password = psw;
                    cadastro.Nome = nome;

                    var jsonText = JSON.stringify(cadastro);

                    var url = "../Login/Cadastar";

                    $.ajax({
                        type: "POST",
                        url: url,
                        cache: false,
                        async: true,
                        data: {
                            user: jsonText
                        },
                        success: function (res) {
                            
                            if (res) {
                                LoginGps.login(psw, user);
                            } else {
                                Swal.fire({
                                    icon: 'warning',
                                    title: 'Email já possui cadastro em nosso sistema',
                                    timer: 2000,
                                    showConfirmButton: false,

                                })
                            }
                            
                        },
                        error: function (res) {

                        }
                    });
                }
            },

            get_cnpj: function () {

                var cnpj = $("#txtBusca").val();
                var url = "../Login/ConsultaCpnjs";
                $(".btn").attr("disabled", true);
                $.ajax({
                    type: "POST",
                    url: url,
                    cache: false,
                    async: true,
                    data: {
                        user: logado,
                        cnpj: cnpj
                    },
                    success: function (res) {
                        $(".btn").attr("disabled", false);
                        if (res != "Error") {
                            $('#FindAtual').empty();
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id="">cnpj - ' + res.cnpj + '</li>');
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id=""> nome - ' +  res.nome + '</li>');
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id="">fantasia - ' +  res.fantasia + '</li>');
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id="">uf - ' + res.uf + '</li>');
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id="">  municipio -' + res.municipio + '</li>');
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id="">logradouro - ' + res.logradouro + '</li>');
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id=""> cep -' + res.cep + '</li>');
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id=""> telefone - ' +res.telefone + '</li>');
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id=""> email - ' +res.email + '</li>');
                            $('#FindAtual').append('<li class="ativContr item-cpp-optin-add" id=""> situacao - ' +res.situacao + '</li>');
                        } else {

                            Swal.fire({
                                icon: 'warning',
                                title: 'CNPJ Invalido!!!!',
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

            get_cnpj_save: function () {
                var url = "../Login/ConsultaCpnjsSave";
                
                $.ajax({
                    type: "POST",
                    url: url,
                    cache: false,
                    async: true,
                    data: {
                        user: logado
                    },
                    success: function (res) {
                      
                        if (res.cnps.length > 0) {
                            $('#FindsAall').empty();
                            
                            for (var i = 0; i < res.cnps.length; i++) {
                                let cpp = '<ul id="' + res.cnps[i].cnpj +'" style="margin:5px;  background: #efe8e4;border: solid 2px #434a4a;border-radius: 18px;">';
                                cpp += '<li class="ativContr item-cpp-optin-add" id="">cnpj - ' + res.cnps[i].cnpj + '</li>';                                
                                cpp +='<li class="ativContr item-cpp-optin-add" id=""> nome - ' + res.cnps[i].nome + '</li>';
                                cpp += '<li class="ativContr item-cpp-optin-add" id="">fantasia - ' + res.cnps[i].fantasia + '</li>';
                                cpp += '</ul>';
                                
                                $('#FindsAall').append(cpp);
                            }
                            
                        } else {

                            Swal.fire({
                                icon: 'warning',
                                title: 'Não existe CNPJ salvo',
                                timer: 2000,
                                showConfirmButton: false,

                            })
                        }
                    },
                    error: function (res) {
                        
                    }
                });
            },

            savecnpj: function () {
                var cnpj = $("#txtBusca").val();
                url = '../Login/SaveCnpj'
                $(".btn").attr("disabled", true);
                $.ajax({
                    type: "POST",
                    url: url,
                    cache: false,
                    async: true,
                    data: {
                        user: logado,
                        cnpj: cnpj
                    },
                    success: function (res) {
                        $(".btn").attr("disabled", false);
                        if (res) {
                            LoginGps.get_cnpj_save();
                        } else {
                            Swal.fire({
                                icon: 'warning',
                                title: 'Erro ao save CNPJ',
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
