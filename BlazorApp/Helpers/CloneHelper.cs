using AutoMapper;
using _26_01_25.Helpers.Interfaces;

namespace _26_01_25.Helpers
{
    public class CloneHelper : ICloneHelper
    {
        private readonly IMapper _mapper;

        public CloneHelper(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Создаёт копию объекта.
        /// </summary>
        /// <typeparam name="T">Тип объекта.</typeparam>
        /// <param name="source">Исходный объект.</param>
        /// <returns>Копия объекта.</returns> 
        public T Clone<T>(T source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            var clone = _mapper.Map<T>(source);
            Console.WriteLine($"Клонирован объект: {clone}");
            return clone;
        }


    }
}
