using OnilneFlightBooking.Entity;
using OnlineFlightBooking.Models;

namespace OnlineFlightBooking.App_Start
{
    public class MapConfig
    {
        public static void RegisterMap()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                config.CreateMap<SignUpModel, User>();
                config.CreateMap<SignInModel, User>();
                config.CreateMap<FlightModel, Flight>();
                config.CreateMap<FlightTravelClassModel, FlightTravelClass>();
                config.CreateMap<SearchFlight, Flight>();
                config.CreateMap<TicketBookModel,TicketBook>();
            });
        }
    }
}