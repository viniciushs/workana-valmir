namespace BackEnd.Application.AutoMapper
{
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;
    using global::AutoMapper;

    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            this.CreateMap<Cargo, CargoViewModel>()
                .MaxDepth(1)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdCargo));

            this.CreateMap<FormaPagto, FormaPagamentoViewModel>()
                .MaxDepth(1)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdFormaPagto));

            this.CreateMap<Franqueado, FranqueadoViewModel>()
                .MaxDepth(1)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdFranqueado));

            this.CreateMap<Funcionario, FuncionarioViewModel>()
                .MaxDepth(1)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdFuncionario));

            this.CreateMap<Situacao, SituacaoViewModel>()
                .MaxDepth(1)
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.IdSituacao));
        }
    }
}
