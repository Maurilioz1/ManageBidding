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
                "lengthMenu": "Exibir _MENU_ registros"
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
