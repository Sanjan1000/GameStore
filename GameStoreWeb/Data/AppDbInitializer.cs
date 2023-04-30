using GameStoreWeb.Data.Enums;
using GameStoreWeb.Data.Static;
using GameStoreWeb.Models;
using Microsoft.AspNetCore.Identity;

namespace GameStoreWeb.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();



                //Actors
                if (!context.Developers.Any())
                {
                    context.Developers.AddRange(new List<Developer>()
                    {
                        new Developer()
                        {
                            FullName = "Studio Wildcard",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/en/8/82/Studio_Wildcard_logo.png"

                        },
                        new Developer()
                        {
                            FullName = "Kojima Productions",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://www.kojimaproductions.jp/sites/default/files/2022-03/ico.kjpmark.unstacked.outline-01.png"
                        },
                        new Developer()
                        {
                            FullName = "FromSoftware",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://1.bp.blogspot.com/-3PvvKyFpqT8/Xv_xt_OU8PI/AAAAAAAAEi8/fgGi7aXRUg85Ou_9_OGr2ecwY5PfDqpZwCLcBGAsYHQ/s1600/FromSoftware_logo.png"
                        },
                        new Developer()
                        {
                            FullName = "Ubisoft",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://cloudfront-us-east-2.images.arcpublishing.com/reuters/YSIZCJEAI5PDDLYHNZZCI5F2FI.jpg"
                        },
                        new Developer()
                        {
                            FullName = "Valve",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://cdn.mos.cms.futurecdn.net/668f55db846ed80689f710f7c0360524.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Producers
                if (!context.Producers.Any())
                {
                    context.Producers.AddRange(new List<Producer>()
                    {
                        new Producer()
                        {
                            FullName = "Doug Kennedy",
                            Bio = "This is the Bio of the first actor",
                            ProfilePictureURL = "https://costar.brightspotcdn.com/2b/4b/22a62be4402f981ac5cc08f363db/kennedy-doug-gradient2.jpg"

                        },
                        new Producer()
                        {
                            FullName = "Hideo Kojima",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://variety.com/wp-content/uploads/2019/12/hideo_kojima_v3.png"
                        },
                        new Producer()
                        {
                            FullName = "Hidetaka Miyazaki",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/thumb/2/22/Hidetaka_Miyazaki%2C_The_Game_Awards_2022_%28cropped%29.png/399px-Hidetaka_Miyazaki%2C_The_Game_Awards_2022_%28cropped%29.png"
                        },
                        new Producer()
                        {
                            FullName = "Yves Guillemot",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://www.europeanceo.com/wp-content/uploads/2012/10/Guillemot.jpg"
                        },
                        new Producer()
                        {
                            FullName = "Gabe Logan Newell",
                            Bio = "This is the Bio of the second actor",
                            ProfilePictureURL = "https://upload.wikimedia.org/wikipedia/commons/4/42/The_International_2018_%2843263984845%29_%28cropped%29.jpg"
                        }
                    });
                    context.SaveChanges();
                }
                //Games
                if (!context.Games.Any())
                {
                    context.Games.AddRange(new List<Game>()
                    {
                        new Game()
                        {
                            Name = "ARK Survival Evolved",
                            Description = "Ark: Survival Evolved is a 2015 action-adventure survival video game developed by Studio Wildcard. In the game, players must survive being stranded on one of several maps filled with roaming dinosaurs, fictional fantasy monsters, and other prehistoric animals, natural hazards, and potentially hostile human players.",
                            Price = 39.50,
                            ImageURL = "https://i.gadgets360cdn.com/products/large/EGS-ARKSurvivalEvolved-StudioWildcard-S2-1200x1600-5b58fdefea9f885c7426e894a1034921-1000x1333-1652880846.jpg",
                            ReleaseDate = DateTime.Now.AddDays(-10),
                            ProducerId = 1,
                            GameCategory = GameCategory.Survival
                        },
                        new Game()
                        {
                            Name = "Death Stranding",
                            Description = "Death Stranding is a 2019 action game developed by Kojima Productions and published by Sony Interactive Entertainment for the PlayStation 4. It is the first game from director Hideo Kojima and Kojima Productions after their split from Konami in 2015.",
                            Price = 29.50,
                            ImageURL = "https://assets-prd.ignimgs.com/2022/01/04/death-stranding-dc-button-1641336982378.jpg",
                            ReleaseDate = DateTime.Now,

                            ProducerId = 2,
                            GameCategory = GameCategory.Action
                        },
                        new Game()
                        {
                            Name = "ELDEN RING",
                            Description = "Elden Ring is a 2022 action role-playing game developed by FromSoftware and published by Bandai Namco Entertainment. Directed by Hidetaka Miyazaki with worldbuilding provided by fantasy writer George R. R. Martin, it was released for PlayStation 4, PlayStation 5, Windows, Xbox One, and Xbox Series X/S on February 25.",
                            Price = 39.50,
                            ImageURL = "https://image.api.playstation.com/vulcan/ap/rnd/202110/2000/aGhopp3MHppi7kooGE2Dtt8C.png",
                            ReleaseDate = DateTime.Now,
                            ProducerId = 3,
                            GameCategory = GameCategory.Adventure
                        },
                        new Game()
                        {
                            Name = "Assassin's Creed Brotherhood",
                            Description = "Assassin's Creed: Brotherhood is a 2010 action-adventure video game developed by Ubisoft Montreal and published by Ubisoft. It is the third major installment in the Assassin's Creed series, and the second chapter in the \"Ezio Trilogy\", as a direct sequel to 2009's Assassin's Creed II.",
                            Price = 39.50,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/thumb/2/2a/Assassins_Creed_brotherhood_cover.jpg/220px-Assassins_Creed_brotherhood_cover.jpg",
                            ReleaseDate = DateTime.Now.AddDays(-10),


                            ProducerId = 4,
                            GameCategory = GameCategory.Action
                        },
                        new Game()
                        {
                            Name = "Counter-Strike: Global Offensive",
                            Description = "Counter-Strike: Global Offensive is a 2012 multiplayer tactical first-person shooter developed by Valve and Hidden Path Entertainment. It is the fourth game in the Counter-Strike series.",
                            Price = 39.50,
                            ImageURL = "https://upload.wikimedia.org/wikipedia/en/6/6e/CSGOcoverMarch2020.jpg",
                            ReleaseDate = DateTime.Now.AddDays(-10),


                            ProducerId = 5,
                            GameCategory = GameCategory.FPS
                        },
                        new Game()
                        {
                            Name = "Portal 2",
                            Description = "Portal 2 is a 2011 puzzle-platform video game developed by Valve for Windows, Mac OS X, Linux, PlayStation 3, and Xbox 360. The digital PC version is distributed online by Valve's Steam service, while all retail editions were distributed by Electronic Arts.",
                            Price = 39.50,
                            ImageURL = "https://assets-prd.ignimgs.com/2021/12/08/portal2-1638924084230.jpg",
                            ReleaseDate = DateTime.Now.AddDays(3),


                            ProducerId = 5,
                            GameCategory = GameCategory.Action
                        },
                    });
                    context.SaveChanges();
                }
                //Actors & Games
                if (!context.Developer_Games.Any())
                {
                    context.Developer_Games.AddRange(new List<Developer_Games>()
                    {
                        new Developer_Games()
                        {
                            DeveloperId = 1,
                            GamesId = 1
                        },
                        new Developer_Games()
                        {
                            DeveloperId = 2,
                            GamesId = 2
                        },

                         new Developer_Games()
                        {
                            DeveloperId = 3,
                            GamesId = 3
                        },
                         new Developer_Games()
                        {
                            DeveloperId = 4,
                            GamesId = 4
                        },

                        new Developer_Games()
                        {
                            DeveloperId = 5,
                            GamesId = 5
                        },
                        new Developer_Games()
                        {
                            DeveloperId = 5,
                            GamesId = 6
                        },
                    });
                    context.SaveChanges();
                }
            }

           
        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "borovhai@gmail.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "yesbro");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }
                string appUserEmail = "chotovhai@gmail.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Application User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "hovhai");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }


            }
        }
    }
}