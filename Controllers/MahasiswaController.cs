using Microsoft.AspNetCore.Mvc;
using tpmodul10_103022300071.Models;

namespace tpmodul10_103022300071.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : Controller
    {
        private static List<Mahasiswa> _mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa { Nama = "Dewanta Rahma Satria", Nim = "103022300071" },
            new Mahasiswa { Nama = "Muhammad Fauzan", Nim = "103022300065" },
            new Mahasiswa { Nama = "Rahmah Aisyah", Nim = "103022300014" },
            new Mahasiswa { Nama = "Dhea Sri Noor", Nim = "103022300072" },
            new Mahasiswa { Nama = "Dina Salsabila", Nim = "103022300153" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetAllMahasiswa()
        {
            return Ok(_mahasiswaList);
        }

        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= _mahasiswaList.Count)
                return NotFound("Mahasiswa not found.");

            return Ok(_mahasiswaList[index]);
        }

        [HttpPost]
        public ActionResult AddMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            _mahasiswaList.Add(mahasiswa);
            return Ok("Mahasiswa added successfully.");
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= _mahasiswaList.Count)
                return NotFound("Mahasiswa not found.");

            _mahasiswaList.RemoveAt(index);
            return Ok("Mahasiswa deleted successfully.");
        }
    }
}
