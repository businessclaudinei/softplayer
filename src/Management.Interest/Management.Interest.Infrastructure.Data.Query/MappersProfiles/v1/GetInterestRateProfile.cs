using AutoMapper;
using Management.Interest.Infrastructure.Data.Query.Queries.v1.GetInterestRate;

namespace Management.Interest.Infrastructure.Data.Query.v1.Mappers
{
    public sealed class GetInterestRateProfile:Profile
    {
        public GetInterestRateProfile()
        {
            CreateMap<double?, GetInterestRateQueryResponse>(MemberList.None)
                .ForMember(x => x.InterestRate, opt => opt.MapFrom(src => src.Value))
                .ForMember(x => x.FormattedInterestRate, opt => opt.MapFrom(src => src.Value.ToString("c")));
        }
    }
}
