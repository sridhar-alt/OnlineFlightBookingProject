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
                config.CreateMap<Booking, TicketBook>();
            });
            //config.CreateMap<UserEntityModel, User>().ForMember(dest => dest.Role, opt => opt.MapFrom(src=>MemberRole.User));
        }
    }
}