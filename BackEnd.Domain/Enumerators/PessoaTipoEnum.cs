namespace BackEnd.Domain.Enumerators
{
    using System.ComponentModel;

    public enum PessoaTipoEnum
    {
        [Description("PF")]
        Fisica = 1,

        [Description("PJ")]
        Juridica = 2
    }
}
