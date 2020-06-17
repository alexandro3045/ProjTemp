using FluentValidation.Results;

namespace Aplicacao.Domain.Shared.Model
{
    public abstract class Base
    {
        [System.Text.Json.Serialization.JsonIgnore]
        public ValidationResult ValidationResult { get; set; }

        protected Base()
        {
            ValidationResult = new ValidationResult();
        }
    }

    public abstract class TEntity<Tid> : Base
    {
        public Tid Id { get; set; }
    }
}