namespace BackEnd.Domain.Models
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;

    public abstract class BaseEntity
    {
        ///// <summary>
        /////     A identidade do registro.
        ///// </summary>
        //public int Id { get; set; }

        ///// <summary>
        /////     Indica a data de criação do registro.
        ///// </summary>
        //public DateTime CriadoEm { get; set; }

        ///// <summary>
        /////     Indica se o registro está ativo.
        ///// </summary>
        //public bool Ativo { get; set; }

        //public override bool Equals(object obj)
        //{
        //    var compareTo = obj as BaseEntity;

        //    if (ReferenceEquals(this, compareTo))
        //    {
        //        return true;
        //    }

        //    if (ReferenceEquals(null, compareTo))
        //    {
        //        return false;
        //    }

        //    return this.Id.Equals(compareTo.Id);
        //}

        //public static bool operator ==(BaseEntity a, BaseEntity b)
        //{
        //    if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
        //    {
        //        return true;
        //    }

        //    if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
        //    {
        //        return false;
        //    }

        //    return a.Equals(b);
        //}

        //public static bool operator !=(BaseEntity a, BaseEntity b)
        //{
        //    return !(a == b);
        //}

        //public override int GetHashCode()
        //{
        //    return (this.GetType().GetHashCode() * 907) + this.Id.GetHashCode();
        //}

        //public override string ToString()
        //{
        //    return this.GetType().Name + " [Id=" + this.Id + "]";
        //}

        public BaseEntity Copy()
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, this);
                ms.Position = 0;
                return (BaseEntity)formatter.Deserialize(ms);
            }
        }
    }
}
