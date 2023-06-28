using FluentValidation;
using HomeApi.Contracts.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeApi.Contracts.Validation
{
    /// <summary>
    /// Класс-валидатор запросов обновления комнаты
    /// </summary>
    public class UpdateRoomRequestValidator : AbstractValidator<UpdateRoomRequest>
    {
        /// <summary>
        /// Метод, конструктор, устанавливающий правила
        /// </summary>
        public UpdateRoomRequestValidator() 
        {
            RuleFor(x => x.NewName).NotEmpty();
            RuleFor(x => x.NewArea).NotEmpty();
            RuleFor(x => x.NewGasConnected).NotEmpty();
            RuleFor(x => x.NewVoltage).NotEmpty();
        }
    }
}
