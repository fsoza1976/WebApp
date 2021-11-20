"use strict";
var TipoIdentificacionGrid;
(function (TipoIdentificacionGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "#d33").then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "TipoIdentificacion/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    TipoIdentificacionGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(TipoIdentificacionGrid || (TipoIdentificacionGrid = {}));
//# sourceMappingURL=Grid.js.map