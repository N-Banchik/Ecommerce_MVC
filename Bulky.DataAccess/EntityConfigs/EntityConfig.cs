﻿using Bulky.Models.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bulky.DataAccess.EntityConfigs
{
    internal class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(n => n.Name).IsRequired();
            entity.HasData(new[]
            {
            new Category() { Id=1,Name = "Action", DisplayOrder = 1 },
            new Category() { Id=2,Name = "Fiction", DisplayOrder = 2 },
            new Category() {Id = 3,Name = "Non-Fiction", DisplayOrder = 3 },
            new Category() {Id = 4,Name = "Science fiction", DisplayOrder = 4 }
        });
        }
    }

    internal class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(p => p.Title).IsRequired();
            entity.Property(p => p.ISBN).IsRequired();
            entity.Property(p => p.Author).IsRequired();
            entity.HasOne(c => c.Category).WithMany().HasForeignKey(p => p.CategoryId);
            entity.Property(p => p.ListPrice).IsRequired().HasColumnType("numeric(18,3)");
            entity.Property(p => p.Price).IsRequired().HasColumnType("numeric(18,3)");
            entity.Property(p => p.Price50).IsRequired().HasColumnType("numeric(18,3)");
            entity.Property(p => p.Price100).IsRequired().HasColumnType("numeric(18,3)");
            entity.HasData(new[]
            {
               new Product
            {
                Id = 1,
                Title = "The Catcher in the Rye",
                Author = "J.D. Salinger",
                Description = "A novel about a teenage boy's experiences and thoughts in the days following his expulsion from a prestigious prep school.",
                ISBN = "0316769177",
                CategoryId = 1,
                ListPrice = 99.99,
                Price = 97.99,
                Price50 = 89.99,
                Price100 = 84.99,
                ImageUrl="\\Images\\Product\\91d4d68c-df73-460e-852f-c3a5a95ab58f.jpeg"
            },
            new Product
            {
                Id = 2,
                Title = "To Kill a Mockingbird",
                Author = "Harper Lee",
                Description = "A novel set in the American South during the 1930s, dealing with racial injustice and moral growth through the eyes of a young girl.",
                ISBN = "0060935464",
                CategoryId = 2,
                ListPrice = 79.99,
                Price = 78.39,
                Price50 = 71.99,
                Price100 = 67.99,
                ImageUrl="\\Images\\Product\\b00e17b6-2b75-4325-b8c1-d8aa20f053d5.jpg"
            },
            new Product
            {
                Id = 3,
                Title = "The Great Gatsby",
                Author = "F. Scott Fitzgerald",
                Description = "A novel depicting the lavish and decadent lifestyle of the wealthy elite in the Roaring Twenties, and the disillusionment and emptiness that lies beneath.",
                ISBN = "0743273567",
                CategoryId = 1,
                ListPrice = 129.99,
                Price = 127.39,
                Price50 = 116.99,
                Price100 = 110.49,
                ImageUrl="\\Images\\Product\\a613d850-2772-4650-a518-8ac1582ee8d0.jpg"
            },
            new Product
            {
                Id = 4,
                Title = "Pride and Prejudice",
                Author = "Jane Austen",
                Description = "A classic romance novel about the Bennet family and their five daughters, particularly the headstrong Elizabeth Bennet and her budding relationship with the wealthy Mr. Darcy.",
                ISBN = "0141439513",
                CategoryId =3,
                ListPrice = 59.99,
                Price = 58.79,
                Price50 = 53.99,
                Price100 = 50.99,
                ImageUrl="\\Images\\Product\\6e74fdf6-3cd9-4881-8319-0f2f53e07c07.jpg"
            },

               new Product
            {
                Id = 5,
                Title = "The Stars Beyond",
                Author = "Aria Blackwell",
                Description = "A thrilling space opera about a group of explorers who embark on a dangerous journey to uncover the truth behind an ancient alien artifact.",
                ISBN = "9781534453542",
                CategoryId = 2,
                ListPrice = 99.99,
                Price = 97.99,
                Price50 = 89.99,
                Price100 = 84.99,
                ImageUrl="\\Images\\Product\\0f4304d9-c3e9-4826-a576-574a1f6619a8.jpg"
            },
            new Product
            {
                Id = 6,
                Title = "Nebula's Edge",
                Author = "Xander Steele",
                Description = "A gripping tale of a lone starship captain who must navigate through treacherous space battles and unravel a conspiracy that threatens the fate of the galaxy.",
                ISBN = "9781982143463",
                CategoryId = 2,
                ListPrice = 79.99,
                Price = 78.39,
                Price50 = 71.99,
                Price100 = 67.99,
                ImageUrl="\\Images\\Product\\7fdfaaef-b424-4e3d-8149-18e8f42516e3.jpg"
            },
            new Product
            {
                Id = 7,
                Title = "Time Warp Chronicles",
                Author = "Zara Nova",
                Description = "A mind-bending story of time travel and alternate realities, where the fate of humanity hangs in the balance as a group of unlikely heroes race against time to save the future.",
                ISBN = "9781728314557",
                CategoryId = 4,
                ListPrice = 129.99,
                Price = 127.39,
                Price50 = 116.99,
                Price100 = 110.49,
                ImageUrl="\\Images\\Product\\86d697b5-6932-44eb-9a26-edf6c6e20b2a.jpg"
            },
            new Product
            {
                Id = 8,
                Title = "Cyberpunk Revolution",
                Author = "Raven Cross",
                Description = "A gritty cyberpunk tale set in a dystopian future, where a lone hacker fights against corrupt corporations and ruthless mercenaries in a battle for survival.",
                ISBN = "9781954893208",
                CategoryId = 4,
                ListPrice = 59.99,
                Price = 58.79,
                Price50 = 53.99,
                Price100 = 50.99,
                ImageUrl="\\Images\\Product\\1c73a674-43ed-497a-ba0f-d1c013191a3a.jpg"
            },

            });



        }
    }

    internal class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(n => n.Name).IsRequired();
            entity.HasData(new[]
            {
           new Company { Id = 1,Name="MetroMind",PhoneNumber="+1 202-918-2132",StreetAddress="237-205 E 12th St",City="New York",Country="New York",Zipcode="10003"},
           new Company { Id = 2,Name="OptiTrip",PhoneNumber="+1 505-554-9438",StreetAddress="2475 Grayling St",City="Hamtramck",Country="Michigan",Zipcode="48212"},
           new Company { Id = 3,Name="EliteTransit",PhoneNumber="+49 170 77261952",StreetAddress="Klenzestraße 18",City="München",Country="Germany",Zipcode="80469 "},
        });
            
        }
    }
    internal class AppUserConfig : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c => c.Company).WithOne().HasForeignKey("CompanyId");

        }
    }
    internal class ShoppingCartConfig : IEntityTypeConfiguration<ShoppingCart>
    {
        public void Configure(EntityTypeBuilder<ShoppingCart> entity)
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c => c.Product).WithMany().HasForeignKey("ProductId");
            entity.HasOne(c => c.User).WithMany().HasForeignKey("UserId");

        }
    }

    internal class OrderDetailsConfig : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> entity)
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c => c.Product).WithMany().HasForeignKey("ProductId");
            entity.HasOne(c => c.OrderHeader).WithMany().HasForeignKey("OrderHeaderId");
            entity.Property(o=>o.OrderHeaderId).IsRequired();
            entity.Property(o=>o.ProductId).IsRequired();


        }
    }
    internal class OrderHeadersConfig : IEntityTypeConfiguration<OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> entity)
        {
            entity.HasKey(c => c.Id);
            entity.HasOne(c => c.User).WithMany().HasForeignKey("UserId");
            entity.Property(o => o.UserId).IsRequired();
            entity.Property(o => o.PhoneNumber).IsRequired();
            entity.Property(o => o.Name).IsRequired();
            entity.Property(o => o.StreetAddress).IsRequired();
            entity.Property(o => o.City).IsRequired();
            entity.Property(o => o.Zipcode).IsRequired();
            entity.Property(o => o.Country).IsRequired();


        }
    }


}
