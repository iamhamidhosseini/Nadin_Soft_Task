using task.Data;
using task.Data.Task.Infrastructure.Data;
using task.Models;

namespace task.Features
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly ApplicationDbContext _context;

        public CreateProductCommandHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Name = request.Name,
                ProduceDate = request.ProduceDate,
                ManufacturePhone = request.ManufacturePhone,
                ManufactureEmail = request.ManufactureEmail,
                IsAvailable = request.IsAvailable
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync(cancellationToken);

            return product.Id;
        }
    }

}
