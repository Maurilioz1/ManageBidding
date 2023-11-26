var main = (function () {
    function init() {
        bind();
    }

    function bind() {
        bindDatatable();
    }

    function bindDatatable() {
        $('#bidding-data-table').DataTable({
            "language": {
                "search": "Pesquisar: ",
                "paginate": {
                    "next": ">",
                    "previous": "<"
                },
                "info": "Exibindo _END_ de _TOTAL_ registros",
                "infoEmpty": "Não há gegistros",
                "lengthMenu": "Exibir _MENU_ registros",
                "emptyTable": "Sem dados disponíveis na tabela",
                "infoFiltered": "(_TOTAL_ item(s) filtrado(s))"
            }
        });
    }

    return {
        Init: init
    }
}());

$(function () {
    main.Init();
});
