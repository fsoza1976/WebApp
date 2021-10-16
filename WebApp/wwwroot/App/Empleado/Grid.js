"use strict";
var EmpleadoGrid;
(function (EmpleadoGrid) {
    if (MensajeApp != "") {
        Toast.fire({
            icon: "success", title: MensajeApp
        });
    }
    function OnClickEliminar(id) {
        ComfirmAlert("Desea eliminar el registro?", "Eliminar", "warning", "#3085d6", "#d33").then(function (result) {
            if (result.isConfirmed) {
                window.location.href = "Empleado/Grid?handler=Eliminar&id=" + id;
            }
        });
    }
    EmpleadoGrid.OnClickEliminar = OnClickEliminar;
    $("#GridView").DataTable();
})(EmpleadoGrid || (EmpleadoGrid = {}));
//# sourceMappingURL=Grid.js.map