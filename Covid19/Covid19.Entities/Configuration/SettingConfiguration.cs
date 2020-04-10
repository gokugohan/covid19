using Covid19.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Covid19.Entities.Configuration
{
    public class SettingConfiguration : IEntityTypeConfiguration<Setting>
    {
        public void Configure(EntityTypeBuilder<Setting> builder)
        {
            builder.Property(p => p.CreatedAt).HasDefaultValue(DateTime.Now);
            builder.Property(p => p.UpdatedAt).HasDefaultValue(DateTime.Now);

            var settings = new List<Setting>
            {
                // Site Settings
                new Setting{
                    Id=Guid.NewGuid(),
                    Key="site_name",
                    Name="Site Name",
                    Value="LOREM-IPSUM",
                    Type="text",
                    Group="General"
                },

                new Setting{
                    Id=Guid.NewGuid(),
                    Key="banner",
                    Name="Banner Image",
                    Type="file",
                    Group="General"
                },


                // Contact settings
                new Setting
                {
                    Id=Guid.NewGuid(),
                    Key="contact_address",
                    Value="Rua Delta 1, Aimutin Comoro, Dili. Timor-Leste",
                    Name="Contact address",
                    Type="text",
                    Group="General"
                },
                new Setting
                {
                    Id=Guid.NewGuid(),
                    Key="contact_phone",
                    Value="+(670) 331 017 9",
                    Name="Contact phone",
                    Type="text",
                    Group="General"
                },
                new Setting
                {
                    Id=Guid.NewGuid(),
                    Key="contact_email",
                    Value="helder@chebre.net",
                    Name="Contact email",
                    Type="email",
                    Group="General"
                },

                // Footer Settings
                new Setting
                {
                    Id=Guid.NewGuid(),
                    Key="footer_description",
                    Value="In alias aperiam. Placeat tempore facere. Officiis voluptate ipsam vel eveniet est dolor et totam porro. Perspiciatis ad omnis fugit molestiae recusandae possimus. Aut consectetur id quis. In inventore consequatur ad voluptate cupiditate debitis accusamus repellat cumque.	",
                    Name="Footer Description",
                    Type="textarea",
                    Group="General"
                },

                new Setting
                {
                    Id=Guid.NewGuid(),
                    Key="twitter",
                    Value="#!",
                    Name="Twitter",
                    Type="text",
                    Group="General"

                },
                new Setting
                {
                    Id=Guid.NewGuid(),
                    Key="facebook",
                    Value="#!",
                    Name="Facebook",
                    Type="text",
                    Group="General"
                },
                new Setting
                {
                    Id=Guid.NewGuid(),
                    Key="instagram",
                    Value="#!",
                    Name="Instagram",
                    Type="text",
                    Group="General"
                },
                new Setting
                {
                    Id=Guid.NewGuid(),
                    Key="linkedin",
                    Value="#!",
                    Name="LinkedIn",
                    Type="text",
                    Group="General"
                }
            };

            builder.HasData(settings);
        }
    }
}
