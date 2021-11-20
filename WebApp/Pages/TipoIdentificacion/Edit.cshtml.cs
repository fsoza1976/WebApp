using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.TipoIdentificacion
{
    public class EditModel : PageModel
    {
        private readonly ITipoIdentificacionService tipoIdentificacionService;

        public EditModel(ITipoIdentificacionService tipoIdentificacionService)
        {
            this.tipoIdentificacionService = tipoIdentificacionService;
        }

        [BindProperty]
        public TipoIdentificacionEntity Entity { get; set; } = new TipoIdentificacionEntity();

        [BindProperty(SupportsGet =true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await tipoIdentificacionService.GetById(new() { IdTipoIdentificacion = id });
                }
                return Page();
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }
        }


        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                //Método actualizar
                if (Entity.IdTipoIdentificacion.HasValue)
                {
                    var result = await tipoIdentificacionService.Update(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha actualizado.";
                }
                else
                {
                    var result = await tipoIdentificacionService.Create(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha insertado.";
                }
                return RedirectToPage("Grid");
            }
            catch (Exception ex)
            {

                return Content(ex.Message);
            }

        }
    }
}
