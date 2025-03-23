using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Models;

namespace Repository.Configurations
{
    internal class FrameConfiguration : IEntityTypeConfiguration<Frame>
    {
        public void Configure(EntityTypeBuilder<Frame> builder)
        {
            builder.HasData(
                new Frame
                {
                    Id = 1,
                    Description = "Description",
                    FrameNumber = 1,
                    MaxThrows = 2,

                },
                new Frame
                {
                    Id = 2,
                    Description = "Description 2",
                    FrameNumber = 2,
                    MaxThrows = 2,
                },
                new Frame
                {
                    Id = 3,
                    Description = "Description 3",
                    FrameNumber = 3,
                    MaxThrows = 2,
                },
                 new Frame
                 {
                     Id = 4,
                     Description = "Description 4",
                     FrameNumber = 4,
                     MaxThrows = 2,
                 },
                new Frame
                {
                    Id = 5,
                    Description = "Description 5",
                    FrameNumber = 5,
                    MaxThrows = 2,
                },
                new Frame
                {
                    Id = 6,
                    Description = "Description 6",
                    FrameNumber = 6,
                    MaxThrows = 2,

                },
                new Frame
                {
                    Id = 7,
                    Description = "Description 7",
                    FrameNumber = 7,
                    MaxThrows = 2,
                },
                new Frame
                {
                    Id = 8,
                    Description = "Description 8",
                    FrameNumber = 8,
                    MaxThrows = 2,
                },
                 new Frame
                 {
                     Id = 9,
                     Description = "Description 9",
                     FrameNumber = 9,
                     MaxThrows = 2,
                 },
                new Frame
                {
                    Id = 10,
                    Description = "Description 10",
                    FrameNumber = 10,
                    MaxThrows = 3,
                }
            );
        }
    }
}
