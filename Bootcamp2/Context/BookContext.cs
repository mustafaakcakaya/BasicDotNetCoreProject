using Bootcamp2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bootcamp2.Context
{
    public class BookContext
    {
        public List<BookEntity> Books { get; set; }

        public BookContext()
        {
            Books = new List<BookEntity>() {
                new BookEntity(){
                    Id =1,
                    Author="Sebahattın Ali",
                    Name = "Kuyucaklı Yusuf",
                    Publisher="YapıKredi Yayınları"
                },
                new BookEntity(){
                    Id =2,
                    Author="Micheal Ende",
                    Name = "Mom",
                    Publisher="Kırmızı Kedi Yayınları"
                },
                new BookEntity(){
                    Id =3,
                    Author="George Orwell",
                    Name = "1984",
                    Publisher="Bilinmeyen Yayınları"
                }
            };
        }
    }
}
