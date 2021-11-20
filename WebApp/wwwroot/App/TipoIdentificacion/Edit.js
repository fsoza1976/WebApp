"use strict";
var TipoIdentificacionEdit;
(function (TipoIdentificacionEdit) {
    var Formulario = new Vue({
        data: {
            Formulario: "#FormEdit"
        },
        mounted: function () {
            CreateValidator(this.Formulario);
        }
    });
    Formulario.$mount("#AppEdit");
})(TipoIdentificacionEdit || (TipoIdentificacionEdit = {}));
//# sourceMappingURL=Edit.js.map