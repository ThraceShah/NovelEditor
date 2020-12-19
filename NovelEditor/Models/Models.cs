using System;
using System.Collections.Generic;
using System.IO;

namespace Novel.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string CoverImage { get; set; }
    }
    public class BookManager
    {
        public static List<Book> GetBooks()
        {
            var books = new List<Book>();

            books.Add(new Book { BookId = 1, Title = "Vulpate", Author = "Futurum", CoverImage = "Assets/1.png" });
            books.Add(new Book { BookId = 2, Title = "Mazim", Author = "Sequiter Que", CoverImage = "Assets/2.png" });
            books.Add(new Book { BookId = 3, Title = "Elit", Author = "Tempor", CoverImage = "Assets/3.png" });
            books.Add(new Book { BookId = 4, Title = "Etiam", Author = "Option", CoverImage = "Assets/4.png" });
            books.Add(new Book { BookId = 5, Title = "Feugait Eros Libex", Author = "Accumsan", CoverImage = "Assets/5.png" });
            books.Add(new Book { BookId = 6, Title = "Nonummy Erat", Author = "Legunt Xaepius", CoverImage = "Assets/6.png" });
            books.Add(new Book { BookId = 7, Title = "Nostrud", Author = "Eleifend", CoverImage = "Assets/7.png" });
            books.Add(new Book { BookId = 8, Title = "Per Modo", Author = "Vero Tation", CoverImage = "Assets/8.png" });
            books.Add(new Book { BookId = 9, Title = "Suscipit Ad", Author = "Jack Tibbles", CoverImage = "Assets/9.png" });
            books.Add(new Book { BookId = 10, Title = "Decima", Author = "Tuffy Tibbles", CoverImage = "Assets/10.png" });
            books.Add(new Book { BookId = 11, Title = "Erat", Author = "Volupat", CoverImage = "Assets/11.png" });
            books.Add(new Book { BookId = 12, Title = "Consequat", Author = "Est Possim", CoverImage = "Assets/12.png" });
            books.Add(new Book { BookId = 13, Title = "Aliquip", Author = "Magna", CoverImage = "Assets/13.png" });

            return books;
        }
    }

    public class VolumeChapter
    {
        public string Name { get; set; }
        public List<VolumeChapter> Chapters { get; set; }
    }
    public class VolumeManager
    {
        public static List<VolumeChapter> GetVolume()
        {
            var volumes = new List<VolumeChapter>();
            for (int i = 0; i < 20; i++)
            {
                volumes.Add(new VolumeChapter { Name="第"+i+"卷", Chapters = GetChapters() });
            }
            return volumes;
        }
        public static List<VolumeChapter> GetChapters()
        {
            var chapters = new List<VolumeChapter>();
            for (int i = 0; i < 10; i++)
                chapters.Add(new VolumeChapter { Name = "第" + i + "章" });
            return chapters;
        }
    }

    public class Filedeal
    {
        List<String> list = new List<String>();

        public void director(string dirs)
        {
            //绑定到指定的文件夹目录
            DirectoryInfo dir = new DirectoryInfo(dirs);
            //检索表示当前目录的文件和子目录
            FileSystemInfo[] fsinfos = dir.GetFileSystemInfos();
            //遍历检索的文件和子目录
            foreach (FileSystemInfo fsinfo in fsinfos)
            {
                //判断是否为空文件夹　　
                if (fsinfo is DirectoryInfo)
                {
                    //递归调用
                    director(fsinfo.FullName);
                }
                else
                {
                    Console.WriteLine(fsinfo.FullName);
                    //将得到的文件全路径放入到集合中
                    list.Add(fsinfo.FullName);
                }
            }
        }
    }
}
