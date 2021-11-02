"use strict";
var EmpleadoEdit;
(function (EmpleadoEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(EmpleadoEdit || (EmpleadoEdit = {}));
//# sourceMappingURL=Edit.js.map