using AutoMapper;
using BLL.DTO.Request;
using BLL.DTO.Response;
using BLL.Services.Interfaces;
using ConsumerAPI.Controllers.Interfaces;
using DAL.Entities;
using DAL.Pagination;
using DAL.Parameters;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerCatalogTests.TestConsumerController
{
    public class ConsumerServiceFake : IConsumerService
    {
        private readonly IMapper Mapper;
        private readonly List<Consumer> ConsumerList; 

        public ConsumerServiceFake()
        {
            ConsumerList = new List<Consumer>()
            {
                new Consumer()
                {
                    Id = 1,
                    FirstName = "Roland",
                    LastName = "Deschain",
                    OwnedUnit = new List<Unit>
                    {
                        new Unit()
                        {
                            Id = 1,
                            Name = "Flat",
                            OwnerId = 1,
                            Adress = "Lviv",
                            ConsumeEnergy = new List<EnergyConsume>()
                            {
                                new EnergyConsume()
                                {
                                    Id = 1,
                                    Date = DateTime.Now - TimeSpan.FromDays(1),
                                    SizeDay = 100,
                                    SizeNight = 70,
                                    UnitId = 1
                                },
                                new EnergyConsume()
                                {
                                    Id = 2,
                                    Date = DateTime.Now,
                                    SizeDay = 90,
                                    SizeNight = 60,
                                    UnitId = 1
                                },
                                new EnergyConsume()
                                {
                                    Id = 3,
                                    Date = DateTime.Now - TimeSpan.FromDays(2),
                                    SizeDay = 110,
                                    SizeNight = 75,
                                    UnitId = 1
                                }
                            },
                            Issues = new List<Issue>()
                            {
                                new Issue()
                                {
                                    Id = 1,
                                    Status = false,
                                    UnitId = 1,
                                    Title = "Issue 1"
                                },
                                new Issue()
                                {
                                    Id = 2,
                                    Status = true,
                                    UnitId = 1,
                                    Title = "Issue 2"
                                }
                            }
                        },
                        new Unit()
                        {
                            Id = 2,
                            Name = "House",
                            OwnerId = 1,
                            Adress = "Ternopil",
                            ConsumeEnergy = new List<EnergyConsume>()
                            {
                                new EnergyConsume()
                                {
                                    Id = 4,
                                    Date = DateTime.Now - TimeSpan.FromDays(1),
                                    SizeDay = 100,
                                    SizeNight = 70,
                                    UnitId = 2
                                },
                                new EnergyConsume()
                                {
                                    Id = 5,
                                    Date = DateTime.Now,
                                    SizeDay = 90,
                                    SizeNight = 60,
                                    UnitId = 2
                                },
                                new EnergyConsume()
                                {
                                    Id = 6,
                                    Date = DateTime.Now - TimeSpan.FromDays(2),
                                    SizeDay = 110,
                                    SizeNight = 75,
                                    UnitId = 2
                                }
                            },
                            Issues = new List<Issue>()
                            {
                                new Issue()
                                {
                                    Id = 3,
                                    Status = false,
                                    UnitId = 2,
                                    Title = "Issue 1"
                                },
                                new Issue()
                                {
                                    Id = 4,
                                    Status = false,
                                    UnitId = 2,
                                    Title = "Issue 2"
                                }
                            }
                        }
                    }                    
                },
                new Consumer()
                {
                    Id = 2,
                    FirstName = "Alain",
                    LastName = "Johns",
                    OwnedUnit = new List<Unit>
                    {
                        new Unit()
                        {
                            Id = 3,
                            Name = "Flat",
                            OwnerId = 2,
                            Adress = "Cherkasy",
                            ConsumeEnergy = new List<EnergyConsume>()
                            {
                                new EnergyConsume()
                                {
                                    Id = 7,
                                    Date = DateTime.Now - TimeSpan.FromDays(1),
                                    SizeDay = 100,
                                    SizeNight = 70,
                                    UnitId = 3
                                },
                                new EnergyConsume()
                                {
                                    Id = 8,
                                    Date = DateTime.Now,
                                    SizeDay = 90,
                                    SizeNight = 60,
                                    UnitId = 3
                                },
                                new EnergyConsume()
                                {
                                    Id = 9,
                                    Date = DateTime.Now - TimeSpan.FromDays(2),
                                    SizeDay = 110,
                                    SizeNight = 75,
                                    UnitId = 3
                                }
                            },
                            Issues = new List<Issue>()
                            {
                                new Issue()
                                {
                                    Id = 5,
                                    Status = true,
                                    UnitId = 1,
                                    Title = "Issue 1"
                                },
                                new Issue()
                                {
                                    Id = 6,
                                    Status = true,
                                    UnitId = 1,
                                    Title = "Issue 2"
                                }
                            }
                        },
                        new Unit()
                        {
                            Id = 4,
                            Name = "House",
                            OwnerId = 2,
                            Adress = "Ternopil",
                            ConsumeEnergy = new List<EnergyConsume>()
                            {
                                new EnergyConsume()
                                {
                                    Id = 10,
                                    Date = DateTime.Now - TimeSpan.FromDays(1),
                                    SizeDay = 100,
                                    SizeNight = 70,
                                    UnitId = 4
                                },
                                new EnergyConsume()
                                {
                                    Id = 11,
                                    Date = DateTime.Now,
                                    SizeDay = 90,
                                    SizeNight = 60,
                                    UnitId = 3
                                },
                                new EnergyConsume()
                                {
                                    Id = 12,
                                    Date = DateTime.Now - TimeSpan.FromDays(2),
                                    SizeDay = 110,
                                    SizeNight = 75,
                                    UnitId = 3
                                }
                            },
                            Issues = new List<Issue>()
                            {
                                new Issue()
                                {
                                    Id = 7,
                                    Status = false,
                                    UnitId = 4,
                                    Title = "Issue 1"
                                },
                                new Issue()
                                {
                                    Id = 8,
                                    Status = true,
                                    UnitId = 4,
                                    Title = "Issue 2"
                                }
                            }
                        }
                    }
                },
                new Consumer()
                {
                    Id = 3,
                    FirstName = "Cuthbert",
                    LastName = "Allgood",
                    OwnedUnit = new List<Unit>
                    {
                        new Unit()
                        {
                            Id = 5,
                            Name = "Flat",
                            OwnerId = 3,
                            Adress = "Kyiv",
                            ConsumeEnergy = new List<EnergyConsume>()
                            {
                                new EnergyConsume()
                                {
                                    Id = 13,
                                    Date = DateTime.Now - TimeSpan.FromDays(1),
                                    SizeDay = 100,
                                    SizeNight = 70,
                                    UnitId = 5
                                },
                                new EnergyConsume()
                                {
                                    Id = 14,
                                    Date = DateTime.Now,
                                    SizeDay = 90,
                                    SizeNight = 60,
                                    UnitId = 5
                                },
                                new EnergyConsume()
                                {
                                    Id = 15,
                                    Date = DateTime.Now - TimeSpan.FromDays(2),
                                    SizeDay = 110,
                                    SizeNight = 75,
                                    UnitId = 5
                                }
                            },
                            Issues = new List<Issue>()
                            {
                                new Issue()
                                {
                                    Id = 9,
                                    Status = true,
                                    UnitId = 5,
                                    Title = "Issue 1"
                                },
                                new Issue()
                                {
                                    Id = 10,
                                    Status = true,
                                    UnitId = 5,
                                    Title = "Issue 2"
                                }
                            }
                        },
                        new Unit()
                        {
                            Id = 6,
                            Name = "House",
                            OwnerId = 3,
                            Adress = "Ivano-Frankivsk",
                            ConsumeEnergy = new List<EnergyConsume>()
                            {
                                new EnergyConsume()
                                {
                                    Id = 16,
                                    Date = DateTime.Now - TimeSpan.FromDays(1),
                                    SizeDay = 100,
                                    SizeNight = 70,
                                    UnitId = 6
                                },
                                new EnergyConsume()
                                {
                                    Id = 17,
                                    Date = DateTime.Now,
                                    SizeDay = 190,
                                    SizeNight = 60,
                                    UnitId = 6
                                },
                                new EnergyConsume()
                                {
                                    Id = 18,
                                    Date = DateTime.Now - TimeSpan.FromDays(2),
                                    SizeDay = 110,
                                    SizeNight = 75,
                                    UnitId = 6
                                }
                            },
                            Issues = new List<Issue>()
                            {
                                new Issue()
                                {
                                    Id = 11,
                                    Status = false,
                                    UnitId = 6,
                                    Title = "Issue 1"
                                },
                                new Issue()
                                {
                                    Id = 12,
                                    Status = false,
                                    UnitId = 6,
                                    Title = "Issue 2"
                                }
                            }
                        }
                    }
                }
            };
        }

        public async Task DeleteAsync(int id)
        {
            ConsumerList.Remove(ConsumerList.Find(x => x.Id == id));
        }

        public async Task<IEnumerable<ConsumerResponse>> GetAsync()
        {
           return ConsumerList.Select(Mapper.Map<Consumer,ConsumerResponse>);
        }

        public Task<PagedList<ConsumerResponse>> GetAsync(ConsumerParameters parameters)
        {
            throw new NotImplementedException();
        }

        public async Task<ConsumerResponse> GetByIdAsync(int id)
        {
            var Item = ConsumerList.Where(x => x.Id == id).FirstOrDefault();
            return Mapper.Map<ConsumerResponse>(Item);
        }

        public async Task<ConsumerResponse> GetCompleteEntityById(int id)
        {
            var Item = ConsumerList.Where(x => x.Id == id).FirstOrDefault();
            return Mapper.Map<ConsumerResponse>(Item);
        }

        public async Task<IEnumerable<EnergyConsumeResponse>> GetConsumesAsync(int id)
        {
            var Item = ConsumerList.Where(x => x.Id == id).FirstOrDefault();
            var Consumes = Item.OwnedUnit.SelectMany(x => x.ConsumeEnergy);
            return Mapper.Map<IEnumerable<EnergyConsumeResponse>>(Consumes);

        }

        public async Task<IEnumerable<UnitResponse>> GetUnitsAsync(int id)
        {
            var Item = ConsumerList.Where(x => x.Id == id).FirstOrDefault();
            var Units = Item.OwnedUnit.ToList();
            return Mapper.Map<IEnumerable<UnitResponse>>(Units);

        }

        public async Task InsertAsync(ConsumerRequest request)
        {
            var Item = Mapper.Map<Consumer>(request);
            ConsumerList.Add(Item);
        }

        public async Task UpdateAsync(ConsumerRequest request)
        {
            var NewItem = Mapper.Map<Consumer>(request);
            ConsumerList.Remove(ConsumerList.Where(x => x.Id == request.Id).FirstOrDefault());
            ConsumerList.Add(NewItem);
        }
    }
}
