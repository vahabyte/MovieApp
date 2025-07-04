using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieApp.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MovieApp.Data
{
    public class DataSeeding
    {

        public static void Seed(IApplicationBuilder app)
        {
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<MovieContext>();

            context.Database.Migrate();

            var genres = new List<Genre>()
            {

                   new Genre {Name = "Korku",Movies = 
                   new List<Movie>(){

                       new Movie
                        {

                            Title = "Yeni Korku filmi 1",
                            Description = "Zihinlerin derinliklerinde geçen çok katmanlı bir rüya yolculuğunda, bir grup uzman bilinçaltına fikir yerleştirmeye çalışır. Gerçeklik ile rüya arasındaki çizgi giderek bulanıklaşır.",
                            ImageUrl = "1.jpg",
                        },

                       new Movie
                        {

                            Title = "Yeni Korku filmi 2",
                            Description = "Corleone ailesinin başındaki Vito Corleone'nin hikayesi, suç dünyasındaki güç mücadelelerini ve ailenin iç dinamiklerini derinlemesine işler. Mafya sinemasının en güçlü örneklerinden biridir.",
                            ImageUrl = "2.jpg",               
                        },


                   } },
                   new Genre {Name = "Bilim-Kurgu"},
                   new Genre {Name = "Dram"},
                   new Genre {Name = "Romantik"},
                   new Genre {Name = "Savaş"},
            };
            var movies = new List<Movie>()
            {
new Movie
{

    Title = "Inception",
    Description = "Zihinlerin derinliklerinde geçen çok katmanlı bir rüya yolculuğunda, bir grup uzman bilinçaltına fikir yerleştirmeye çalışır. Gerçeklik ile rüya arasındaki çizgi giderek bulanıklaşır.",
    ImageUrl = "1.jpg",
    Genres = new List<Genre>(){genres[0],new Genre() { Name="Yeni Tür" }, genres[1] }
},

new Movie
{

    Title = "The Godfather",
    Description = "Corleone ailesinin başındaki Vito Corleone'nin hikayesi, suç dünyasındaki güç mücadelelerini ve ailenin iç dinamiklerini derinlemesine işler. Mafya sinemasının en güçlü örneklerinden biridir.",
    ImageUrl = "2.jpg",
    Genres = new List<Genre>(){genres[2], genres[4] }
},

new Movie
{

    Title = "Interstellar",
    Description = "Küresel bir kıtlık ve çevresel çöküş sonrası, bir grup astronot yeni bir yaşanabilir gezegen bulmak için solucan deliğinden geçerek bilinmezliğe doğru epik bir yolculuğa çıkar.",
    ImageUrl = "3.jpg",
  Genres = new List<Genre>(){genres[1] }
},

new Movie
{

    Title = "Recep İvedik",
    Description = "Sıradışı ve kaba tavırlarıyla tanınan Recep'in, gündelik hayatın içinde yaşadığı absürt ve komik olaylarla izleyiciyi kahkahaya boğan hikayesi.",
    ImageUrl = "4.jpg",
     Genres = new List<Genre>(){new Genre() { Name="Komedi"}, genres[2] }
},

new Movie
{

    Title = "Ayla",
    Description = "Kore Savaşı'na katılan Türk astsubay Süleyman Dilbirliği'nin savaş alanında bulduğu küçük Koreli bir kıza sahip çıkması ve aralarındaki duygusal bağ, izleyenleri derinden etkiler.",
    ImageUrl = "5.jpg",
    Genres = new List<Genre>(){genres[2], genres[4] }
},

new Movie
{

    Title = "The Shawshank Redemption",
    Description = "Haksız yere ömür boyu hapse mahkum edilen Andy Dufresne'nin, Shawshank hapishanesindeki zekice planıyla yıllar süren bir özgürlük mücadelesini anlatır.",
    ImageUrl = "6.jpg",
   Genres = new List<Genre>(){genres[2], genres[3] }
},



            };
           
            var users = new List<User>()
            {
                new User() {UserName="User a",Email="a_user@gmail.com",Password="a123",ImageUrl="person1.png"},
                new User() {UserName="User b",Email="b_user@gmail.com",Password="b123",ImageUrl="person2.png"},
                new User() {UserName="User c",Email="c_user@gmail.com",Password="c123",ImageUrl="person3.png"},

                new User() {UserName="User d",Email="d_user@gmail.com",Password="d123",ImageUrl="person4.png"}
                };

            var people = new List<Person>()
            {
                 new Person()
                {
                    Name = "Personel 1",
                    Biography = "Tanıtım 1",
                    User = users[0]
                },

                new Person()
                {
                    Name = "Personel 2",
                    Biography = "Tanıtım 2",
                    User = users[1]
                }
                };

            var crews = new List<Crew>() 
            {
                new Crew(){ Movie=movies[0],Person=people[0],Job="Yönetmen"},
                new Crew(){ Movie=movies[0],Person=people[1],Job="Yönetmen Yard."},
            };

            var casts = new List<Cast>() 
            {
                 new Cast(){ Movie=movies[0],Person=people[0],Name="Oyuncu 1",Role="Rol 1"},
                 new Cast(){ Movie=movies[0],Person=people[1],Name="Oyuncu 2",Role="Rol 2"},
            };

            if (context.Database.GetPendingMigrations().Count() == 0) 
            {

                if (context.Genres.Count() == 0)
                {
                    context.Genres.AddRange(genres);



                }

                if (context.Movies.Count() == 0)
                {

                    context.Movies.AddRange(movies);
                
                }
                if (context.Users.Count() == 0)
                {

                    context.Users.AddRange(users);

                }
                if (context.People.Count() == 0)
                {

                    context.People.AddRange(people);

                }
                if (context.Casts.Count() == 0)
                {

                    context.Casts.AddRange(casts);

                }
                if (context.Crews.Count() == 0)
                {

                    context.Crews.AddRange(crews);

                }

                context.SaveChanges();
            }

        }


    }
}
