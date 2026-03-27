using WebApplication1.Models;
using System.Linq;

namespace WebApplication1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            // Buscamos si ya existen recetas. Si es así, no hacemos nada.
            if (context.Recetas.Any())
            {
                // Si ya hay recetas pero no usuarios, agregamos los usuarios solicitados
                if (!context.Usuarios.Any())
                {
                    SeedUsers(context);
                }
                return;
            }

            SeedUsers(context);

            var recetas = new Receta[]
            {
                // Platos Fuertes
                new Receta{ Titulo="Bowl de Quinoa y Garbanzos", Descripcion="Una explosión de proteína vegetal con aguacate y aderezo de limón.", Ingredientes="1 taza de Quinoa, Garbanzos crocantes, Aguacate y espinaca", TiempoPreparacion=25, Categoria="Platosfuertes" },
                new Receta{ Titulo="Lasaña de Berenjena", Descripcion="Capas de berenjena asada con salsa pomodoro y queso de almendras.", Ingredientes="2 Berenjenas grandes, Salsa de tomate natural, Queso vegano", TiempoPreparacion=45, Categoria="Platosfuertes" },
                new Receta{ Titulo="Tacos de Jackfruit al Pastor", Descripcion="Deliciosos tacos veganos con todo el sabor de la piña, cilantro y cebolla.", Ingredientes="Jackfruit marinado, Tortillas de maíz, Piña asada picada", TiempoPreparacion=35, Categoria="Platosfuertes" },
                new Receta{ Titulo="Curry de Lentejas y Coco", Descripcion="Un plato exótico y cremoso con arroz basmati y pan naan vegano.", Ingredientes="Lentejas rojas, Leche de coco, Especias curry", TiempoPreparacion=30, Categoria="Platosfuertes" },

                // Bebidas
                new Receta{ Titulo="Smoothie Verde Detox", Descripcion="Espinaca, piña, jengibre y agua de coco para empezar el día.", Ingredientes="Espinaca, Piña, Jengibre, Agua de Coco", TiempoPreparacion=5, Categoria="Bebidas" },
                new Receta{ Titulo="Leche de Almendras Casera", Descripcion="100% natural, sin conservantes ni azúcares añadidos.", Ingredientes="Almendras, Agua filtrada, Sal marina", TiempoPreparacion=15, Categoria="Bebidas" },
                new Receta{ Titulo="Latte Helado de Matcha y Avena", Descripcion="Dulce, sumamente refrescante y lleno de antioxidantes naturales.", Ingredientes="Té Matcha, Leche de avena, Hielo, Sirop de agave", TiempoPreparacion=10, Categoria="Bebidas" },
                new Receta{ Titulo="Kombucha de Frutos Rojos", Descripcion="Bebida espumosa, fermentada y llena de probióticos beneficiosos.", Ingredientes="Scoby, Té negro, Frutos rojos, Azúcar", TiempoPreparacion=7000, Categoria="Bebidas" }, // 7 dias = 10k minutos aprox
                new Receta{ Titulo="Limonada de Lavanda y Pepino", Descripcion="Hidratante, relajante y perfecta para las tardes calurosas.", Ingredientes="Limones, Pepino, Lavanda culinaria, Agua", TiempoPreparacion=8, Categoria="Bebidas" },

                // Postres
                new Receta{ Titulo="Mousse de Chocolate y Aguacate", Descripcion="Cremoso, dulce y sorprendentemente saludable con cacao puro.", Ingredientes="Aguacate maduro, Cacao en polvo, Sirope de arce", TiempoPreparacion=15, Categoria="Postres" },
                new Receta{ Titulo="Cheesecake de Frutos Rojos", Descripcion="Exquisita base de nueces y relleno de crema de marañón cruda.", Ingredientes="Nueces, Marañón, Frutos rojos, Aceite de coco", TiempoPreparacion=240, Categoria="Postres" },
                new Receta{ Titulo="Brownies Fudge de Batata", Descripcion="Sin harina refinada, extra húmedos, chocolatosos y libres de gluten.", Ingredientes="Batata dulce, Cacao, Harina de almendra", TiempoPreparacion=45, Categoria="Postres" },
                new Receta{ Titulo="Helado Vegano de Pistacho", Descripcion="Un helado sedoso basado en crema de coco entera y pistachos tostados.", Ingredientes="Leche de coco, Pistachos, Vainilla", TiempoPreparacion=360, Categoria="Postres" },
                new Receta{ Titulo="Galletas de Chispas y Alcaravea", Descripcion="Galletas crujientes por fuera y ultra suaves por dentro. Un clásico.", Ingredientes="Harina, Alcaravea, Chispas Veganas", TiempoPreparacion=20, Categoria="Postres" },

                // Snacks
                new Receta{ Titulo="Garbanzos Crujientes", Descripcion="Horneados con paprika y sal marina. El snack proteico perfecto.", Ingredientes="Garbanzos, Paprika, Sal marina, Aceite", TiempoPreparacion=30, Categoria="Snacks" },
                new Receta{ Titulo="Chips de Kale", Descripcion="Hojas frescas de kale deshidratadas con levadura nutricional.", Ingredientes="Kale, Levadura nutricional, Aceite de oliva", TiempoPreparacion=20, Categoria="Snacks" },
                new Receta{ Titulo="Energy Balls de Dátil y Cacao", Descripcion="Bocados dulces densos en energía, ideales para antes de entrenar.", Ingredientes="Dátiles, Cacao, Nueces", TiempoPreparacion=15, Categoria="Snacks" },
                new Receta{ Titulo="Edamame Picante al Vapor", Descripcion="Vainas de soya con un toque audaz de sriracha, lima y sal marina.", Ingredientes="Edamame, Sriracha, Lima, Sal", TiempoPreparacion=8, Categoria="Snacks" },
                new Receta{ Titulo="Palomitas de Queso Vegano", Descripcion="Palomitas de maíz estalladas al aire y revueltas en levadura nutricional.", Ingredientes="Maíz, Levadura Nutricional, Aceite de coco", TiempoPreparacion=5, Categoria="Snacks" },

                // Pasabocas
                new Receta{ Titulo="Hummus Clásico", Descripcion="Cremosa pasta de garbanzo con tahini, acompañado de bastones de vegetales.", Ingredientes="Garbanzos, Tahini, Limón, Ajo", TiempoPreparacion=10, Categoria="Pasabocas" },
                new Receta{ Titulo="Bruschettas de Tomate", Descripcion="Pan campesino tostado con albahaca fresca, ajo y aceite de oliva virgen.", Ingredientes="Pan rústico, Tomate, Albahaca, Ajo", TiempoPreparacion=15, Categoria="Pasabocas" },
                new Receta{ Titulo="Rollitos de Primavera Frescos", Descripcion="Coloridos vegetales crudos envueltos en papel de arroz con salsa de maní.", Ingredientes="Papel de arroz, Zanahoria, Pepino, Aguacate", TiempoPreparacion=25, Categoria="Pasabocas" },
                new Receta{ Titulo="Mini Pinchos de Tofu Glaseado", Descripcion="Tofu extrafirme asado con salsa teriyaki hecha en casa, sésamo y cebollín.", Ingredientes="Tofu, Salsa Teriyaki, Sésamo, Cebollín", TiempoPreparacion=35, Categoria="Pasabocas" },
                new Receta{ Titulo="Champiñones Rellenos", Descripcion="Guisados al horno, rellenos de deliciosa mezcla de espinaca, nuez y ajo.", Ingredientes="Champiñones portobello grandes, Espinaca, Nueces, Ajo", TiempoPreparacion=40, Categoria="Pasabocas" }
            };

            context.Recetas.AddRange(recetas);
            context.SaveChanges();
        }

        private static void SeedUsers(ApplicationDbContext context)
        {
            var users = new Usuario[]
            {
                new Usuario { Nombre = "Francisco", Email = "francisco@greenlife.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Fr1234") },
                new Usuario { Nombre = "Sebastian", Email = "sebastian@greenlife.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Se1234") },
                new Usuario { Nombre = "Darien", Email = "darien@greenlife.com", PasswordHash = BCrypt.Net.BCrypt.HashPassword("Da1234") }
            };

            context.Usuarios.AddRange(users);
            context.SaveChanges();
        }
    }
}
