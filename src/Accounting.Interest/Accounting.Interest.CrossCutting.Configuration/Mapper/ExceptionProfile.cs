using Accounting.Interest.CrossCutting.Configuration.ExceptionModels;
using Accounting.Interest.CrossCutting.Exception.Base;
using Accounting.Interest.CrossCutting.Exceptions.Base;
using AutoMapper;
using System.Net;

namespace Accounting.Interest.CrossCutting.Configuration.Mapper
{
    public class ExceptionProfile : Profile
    {
        public ExceptionProfile()
        {
            CreateMap<BadRequestCustomException, DefaultExceptionResponse.NotificationObject>();

            CreateMap<ApiHttpCustomException, DefaultExceptionResponse.NotificationObject>()
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src));

            CreateMap<System.Exception, DefaultExceptionResponse.NotificationObject>()
                .ForMember(dest => dest.Message, opt => opt.MapFrom(src => src.Message))
                .ForMember(dest => dest.ResponseCode, opt => opt.MapFrom(src => HttpStatusCode.InternalServerError))
                .ForMember(dest => dest.Details, opt => opt.MapFrom(src => src));
        }
    }
}
