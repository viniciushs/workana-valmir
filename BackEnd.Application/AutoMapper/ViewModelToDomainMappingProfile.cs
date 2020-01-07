namespace BackEnd.Application.AutoMapper
{
    using BackEnd.Application.ViewModel;
    using BackEnd.Domain.Models;
    using global::AutoMapper;
    using System;

    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            this.CreateMap<CargoViewModel, Cargo>()
                .ForMember(dest => dest.IdCargo, opt => opt.MapFrom(src => src.Id));

            this.CreateMap<FormaPagamentoViewModel, FormaPagto>()
                .ForMember(dest => dest.IdFormaPagto, opt => opt.MapFrom(src => src.Id));

            this.CreateMap<FranqueadoViewModel, Franqueado>()
                .ForMember(dest => dest.IdFranqueado, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Cpf, opt => opt.MapFrom(src => src.Cpf.ReplaceNonDigits()))
                .ForMember(dest => dest.Cnpj, opt => opt.MapFrom(src => src.Cnpj.ReplaceNonDigits()));

            this.CreateMap<FuncionarioViewModel, Funcionario>()
                .ForMember(dest => dest.IdFuncionario, opt => opt.MapFrom(src => src.Id));
            
            this.CreateMap<SituacaoViewModel, Situacao>()
                .ForMember(dest => dest.IdSituacao, opt => opt.MapFrom(src => src.Id));
        }
    }
}
