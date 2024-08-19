using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RSGymPT.ClientManagement.Data;
using RSGymPT.ClientManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace RSGymPT.ClientManagement.Controllers
{
    
    public class ClientesController : Controller
    {
        private readonly RSGymPTContext _context;

        #region Constructor
        public ClientesController(RSGymPTContext context)
        {
            _context = context;
        }
        #endregion

        #region ActionMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> List()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes);
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]

        #region Create
        public async Task<IActionResult> Create([Bind("Id,Nome,TipoPagamento,Fidelizado,MesesFidelizacao,ValorMensalidade,ServicosUtilizados")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                if (cliente.TipoPagamento == "Mensal")
                {
                    if (cliente.Fidelizado == true)
                    {
                        cliente.ServicosUtilizados = 999; // Máximo de serviços
                    }
                    else
                    {
                        cliente.ServicosUtilizados = 2; // Apenas 2 serviços disponíveis
                    }
                }
                else if (cliente.TipoPagamento == "Pontual")
                {
                    cliente.ServicosUtilizados = 1; // Apenas 1 serviço disponível
                    cliente.Fidelizado = false; // Fidelização não aplicável
                }

                // Aplica o desconto se aplicável
                cliente.ValorMensalidade = cliente.CalcularValorComDesconto();

                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(List));
            }
            return View(cliente);
        }
        #endregion

        #region Edit Condition
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        #endregion

        #region Edit
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,TipoPagamento,Fidelizado,MesesFidelizacao,ValorMensalidade,ServicosUtilizados")] Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(List));
            }
            return View(cliente);
        }
        #endregion

        #region Delete
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente); // Exibe a view de confirmação
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        #endregion

        #region Delete Confirmed
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(List)); // Voltar para a lista após exclusão
        }
        #endregion

        #region Details
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }
        #endregion

        #region ClienteExists
        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
        #endregion


    }
}
