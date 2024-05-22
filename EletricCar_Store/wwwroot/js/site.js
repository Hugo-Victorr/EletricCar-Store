function buscaCEP() {
    var cep = document.getElementById("cep").value;
    cep = cep.replace('-', ''); // removemos o traço do CEP
    if (cep.length > 0) {
        var linkAPI = 'https://viacep.com.br/ws/' + cep + '/json/';
        $.ajax({
            url: linkAPI,
            beforeSend: function () {
                document.getElementById("logradouro").value = '...';
                document.getElementById("bairro").value = '...';
                document.getElementById("localidade").value = '...';
                document.getElementById("uf").value = '...';
            },
            success: function (dados) {
                if (dados.erro != undefined) // quando o CEP não existe...
                {
                    alert('CEP não localizado...');
                    document.getElementById("logradouro").value = '';
                    document.getElementById("bairro").value = '';
                    document.getElementById("localidade").value = '';
                    document.getElementById("uf").value = '';
                }
                else // quando o CEP existe
                {
                    document.getElementById("logradouro").value = dados.logradouro;
                    document.getElementById("bairro").value = dados.bairro;
                    document.getElementById("localidade").value = dados.localidade;
                    document.getElementById("uf").value = dados.uf; 
                    document.getElementById("numero").focus();

                }
            }
        });
    }
}

function apagarEndereco(id) {
    if (confirm('Confirma a exclusão do registro?'))
        location.href = 'address/Delete?id=' + id;
}

function apagarMarca(id) {
    if (confirm('Confirma a exclusão do registro?'))
        location.href = 'brand/Delete?id=' + id;
}

function apagar(id) {
    if (confirm('Confirma a exclusão do registro?'))
        location.href = 'brand/Delete?id=' + id;
}