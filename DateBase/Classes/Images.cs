using System;
using System.Drawing;
using System.IO;
using System.Windows.Media.Imaging;

namespace DateBase
{
    internal class Images
    {
        /// <summary>
        /// Преобразует байтовый массив в изображение
        /// </summary>
        /// <param name="photo">Байтовый массив (объект типа Photos)</param>
        /// <returns>Объект типа BitmapImage (изображение)</returns>
        public static BitmapImage GetBitmapImage(Photos photo)
        {
            if (photo != null&& photo.binary_photo!=null)
            {
                byte[] array = photo.binary_photo;
                BitmapImage image = new BitmapImage();

                using (MemoryStream ms = new MemoryStream(array))
                {
                    image.BeginInit();
                    image.StreamSource = ms;
                    image.CacheOption = BitmapCacheOption.OnLoad;
                    image.EndInit();
                }

                return image;
            }
            else if (photo != null && photo.path_photo != null)
            {
                return new BitmapImage(new Uri(photo.path_photo, UriKind.RelativeOrAbsolute));
            }

            return new BitmapImage(new Uri("\\image\\logotip.png", UriKind.RelativeOrAbsolute));
        }

        /// <summary>
        /// Добавляет фото в базу данных
        /// </summary>
        /// <param name="path">Путь к фото</param>
        /// <param name="entity">Вид добавления: true - сотрудник, false - sites</param>
        /// <param name="id">Код </param>

        public static bool AddPhoto(string path, bool entity, int id)
        {
            try
            {
                Photos photo = new Photos();
                if (entity)
                {
                    photo.id_employee = id;
                }
                else
                {
                    photo.id_sites = id;
                }

                Image sdi = Image.FromFile(path);
                ImageConverter ic = new ImageConverter();

                byte[] array = (byte[])ic.ConvertTo(sdi, typeof(byte[]));
                photo.binary_photo = array;

                DBase.ZE.Photos.Add(photo);
                DBase.ZE.SaveChanges();

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
