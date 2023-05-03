//namespace ApplicationDevelopment.WebApi.Controllers
//{
//    public class Utils
//    {
//        public async Task<IActionResult> Approve(Guid id, RequestStatus status)
//        {
//            var rentalModel = await _context.CarRequest.FindAsync(id);

//            if (rentalModel == null)
//            {
//                return NotFound();
//            }

//            rentalModel.RequestStatus = status;

//            await _context.SaveChangesAsync();

//            return Ok();
//        }
//    }
//}


