using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entity;
using WBL;

namespace WebApp.Pages.Empleado
{
    public class EditModel : PageModel
    {
        private readonly IEmpleadoService empleadoService;

        public EditModel(IEmpleadoService empleadoService)
        {
            this.empleadoService = empleadoService;
        }

        [BindProperty]
        public EmpleadoEntity Entity { get; set; } = new EmpleadoEntity();

        [BindProperty(SupportsGet =true)]
        public int? id { get; set; }

        public async Task<IActionResult> OnGet()
        {
            try
            {
                if (id.HasValue)
                {
                    Entity = await empleadoService.GetById(new() { IdEmpleado = id });
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
                if (Entity.IdEmpleado.HasValue)
                {
                    var result = await empleadoService.Update(Entity);
                    if (result.CodeError != 0) throw new Exception(result.MsgError);
                    TempData["Msg"] = "El registro se ha actualizado.";
                }
                else
                {
                    var result = await empleadoService.Create(Entity);
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
