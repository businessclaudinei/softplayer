using AutoMapper;
using Management.Interest.CrossCutting.Configuration.CustomModels;
using Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate;

namespace Management.Interest.Infrastructure.Data.Query.v1.Mappers
{
    public sealed class GetInterestRateProfile:Profile
    {
        public GetInterestRateProfile()
        {
            CreateMap<double?, GetInterestRateQueryResponse>(MemberList.None)
                .ForMember(x => x.InterestRate, opt => opt.MapFrom(src => src.Value))
                .ForMember(x => x.CurrencyCode, opt => opt.MapFrom(src => CustomSettings.Settings.Interest.Cache.DefaultCurrencyCode));
        }
    }
}
