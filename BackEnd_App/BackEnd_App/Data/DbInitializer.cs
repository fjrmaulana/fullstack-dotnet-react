namespace BackEnd_App.Data
{
    public class DbInitializer
    {
        public static async Task SeedData(BackEnd_App.Data.AppDbContext context)
        {
            // 🚀 Cek apakah tabel Activities sudah ada isinya atau belum
            if (context.Activities.Any())
            {
                return; // Jika sudah ada data, hentikan proses (jangan duplikat)
            }

            // Jika kosong, siapkan 10 data tiruan untuk skenario aplikasi ReactJS nanti
            var activities = new List<BackEnd_App.Models.Activity>
            {
                new() {
                    Title = "Konser Musik Indie Jakarta",
                    Date = DateTime.UtcNow.AddMonths(1),
                    Description = "Konser musik akhir pekan yang menampilkan band lokal papan atas.",
                    Category = "Musik",
                    City = "Jakarta",
                    Venue = "Gelora Bung Karno",
                    Langitude = -6.2183,
                    Longitude = 106.8024
                },
                new() {
                    Title = "Workshop ReactJS untuk Pemula",
                    Date = DateTime.UtcNow.AddMonths(2),
                    Description = "Belajar dasar-dasar ReactJS, komponen, dan state management dasar.",
                    Category = "Edukasi",
                    City = "Bandung",
                    Venue = "Bandung Digital Hub",
                    Langitude = -6.9175,
                    Longitude = 107.6191
                },
                new() {
                    Title = "Pameran Seni Kontemporer",
                    Date = DateTime.UtcNow.AddMonths(-1), // Aktivitas yang sudah lewat
                    Description = "Melihat karya seni lukis dan instalasi dari seniman berbakat Asia Tenggara.",
                    Category = "Budaya",
                    City = "Yogyakarta",
                    Venue = "Jogja National Museum",
                    Langitude = -7.8012,
                    Longitude = 110.3644
                },
                new() {
                    Title = "Festival Kuliner Nusantara",
                    Date = DateTime.UtcNow.AddMonths(3),
                    Description = "Menikmati ratusan hidangan tradisional legendaris dari Sabang sampai Merauke.",
                    Category = "Kuliner",
                    City = "Surabaya",
                    Venue = "Grand City Convention",
                    Langitude = -7.2625,
                    Longitude = 112.7483
                },
                new() {
                    Title = "Tech Conference .NET 10",
                    Date = DateTime.UtcNow.AddMonths(4),
                    Description = "Membahas fitur terbaru di .NET 10 dan masa depan kompilasi C#.",
                    Category = "Teknologi",
                    City = "Jakarta",
                    Venue = "Mulia Hotel Ballrom",
                    Langitude = -6.2205,
                    Longitude = 106.7997
                },
                new() {
                    Title = "Maraton Internasional Bali",
                    Date = DateTime.UtcNow.AddMonths(5),
                    Description = "Lari maraton tahunan dengan rute pemandangan alam dan pantai Bali yang indah.",
                    Category = "Olahraga",
                    City = "Gianyar",
                    Venue = "Stadion Kapten I Wayan Dipta",
                    Langitude = -8.5369,
                    Longitude = 115.3114
                },
                new() {
                    Title = "Seminar UI/UX & Desain Produk",
                    Date = DateTime.UtcNow.AddMonths(-2), // Sudah lewat
                    Description = "Strategi membangun desain produk digital yang berorientasi pada kemudahan pengguna.",
                    Category = "Desain",
                    City = "Semarang",
                    Venue = "Hotel Tentrem",
                    Langitude = -6.9827,
                    Longitude = 110.4229
                },
                new() {
                    Title = "Nonton Bareng Final Liga Champions",
                    Date = DateTime.UtcNow.AddMonths(6),
                    Description = "Kumpul komunitas pecinta sepak bola untuk mendukung tim kesayangan di layar raksasa.",
                    Category = "Olahraga",
                    City = "Medan",
                    Venue = "Merdeka Walk",
                    Langitude = 3.5919,
                    Longitude = 98.6756
                },
                new() {
                    Title = "Nobar Film Pendek Indie",
                    Date = DateTime.UtcNow.AddMonths(7),
                    Description = "Apresiasi film karya sineas lokal independen dilanjutkan sesi diskusi sutradara.",
                    Category = "Film",
                    City = "Malang",
                    Venue = "Cineplex Merdeka",
                    Langitude = -7.9826,
                    Longitude = 112.6310
                },
                new() {
                    Title = "Gathering Komunitas Startup Lokal",
                    Date = DateTime.UtcNow.AddMonths(8),
                    Description = "Sesi networking antar founder startup, developer, dan investor lokal.",
                    Category = "Bisnis",
                    City = "Makassar",
                    Venue = "Niko Cafe Lounge",
                    Langitude = -5.1476,
                    Longitude = 119.4327
                }
            };

            // 🚀 Masukkan koleksi data di atas ke memori EF Core
            await context.Activities.AddRangeAsync(activities);

            // 🚀 Eksekusi dan simpan secara fisik ke berkas SQLite (activities.db)
            await context.SaveChangesAsync();
        }
    }
}
