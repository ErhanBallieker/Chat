using Chat.Data.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chat.Data.Context
{
    public class ChatContext : DbContext
    {
        public ChatContext()
        {
            Database.SetInitializer<ChatContext>(null);
            Configuration.LazyLoadingEnabled = true;
        }

        public IDbSet<User> User { get; set; }

        public IDbSet<Message> Message { get; set; }

        public IDbSet<Log> Log { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasRequired(m => m.SenderUser)
                .WithMany(m => m.Messages)
                .HasForeignKey(m => m.SenderUserId);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Messages)
            //    .WithOptional(m => m.ReceiverUser)
            //    .HasForeignKey(m => m.RecevierUserId);

            //modelBuilder.Entity<User>()
            //    .HasMany(u => u.Messages)
            //    .WithRequired(m => m.SenderUser)
            //    .HasForeignKey(m => m.SenderUserId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
