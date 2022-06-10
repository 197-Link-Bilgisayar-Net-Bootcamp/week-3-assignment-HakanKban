using Microsoft.AspNetCore.Mvc;
using Week3.Data.Context;

namespace Week3.API.Controllers
{
    public class StoreProcedur : CustomBaseController
    {

        //Nesne boş geliyor denedim ama çözemedim sql tarafında store procedure çalışıyor
        //using (var _context= new MyContext())
        //{
        //    var product = _context.fullProducts.FromSqlRaw("exec sp_get_FullProduct").ToList();

    }


}

