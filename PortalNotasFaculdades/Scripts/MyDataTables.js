$(document).ready(function () {
    $('#table').DataTable({
        "language": {
            "paginate": {
                "previous": "Anterior",
                "next": "Próximo",
            },
            "zeroRecords": "Nenhum Registro Encontrado",
            "search": "Buscar:",
            "searchPlaceholder": "Buscar Registros...",
            "info": "Mostrando _PAGE_ de _PAGES_ Páginas com Registros",
            "lengthMenu": "Mostrar _MENU_ Registros por Página",
            "infoFiltered": " - Filtrado de _MAX_ Registros",
            "infoEmpty": "Nenhum Registro Encontrado"
        }
    });
});