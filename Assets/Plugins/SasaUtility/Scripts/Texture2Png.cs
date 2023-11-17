using System.IO;
using UnityEngine;
using UnityEngine.UI;

namespace SasaUtility
{
    public static class Texture2Png
    {

        /// <summary>
        /// RawImage���摜�ɕϊ����ۑ�
        /// </summary>
        /// <param name="path">png�̃p�X</param>
        /// <param name="tex">Texture</param>
        public static void ConvertToPngAndSave(string path, RawImage _rawImage)
        {
            Debug.Log(path);
            //Texture2D�ɕϊ�
            //Texture2D Image2D = _RawImage.texture as Texture2D;
            //Png�ɕϊ�
            byte[] bytes = RawImageToPNG(_rawImage);
            //�ۑ�
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// Texture���摜�ɕϊ����ۑ�
        /// </summary>
        /// <param name="path">png�̃p�X</param>
        /// <param name="tex">Texture</param>
        public static void ConvertToPngAndSave(string path, Texture tex)
        {
            Debug.Log(path);
            //Texture2D�ɕϊ�
            //Texture2D Image2D = _RawImage.texture as Texture2D;
            //Png�ɕϊ�
            byte[] bytes = TextureToPNG(tex);
            //�ۑ�
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// Texture2D���摜�ɕϊ����ۑ�
        /// </summary>
        /// <param name="path">png�̃p�X</param>
        /// <param name="tex">Texture</param>
        public static void ConvertToPngAndSave(string path, Texture2D tex2d, bool debug = false)
        {
            if(debug)Debug.Log(path);
            //Texture2D�ɕϊ�
            //Texture2D Image2D = _RawImage.texture as Texture2D;
            //Png�ɕϊ�
            byte[] bytes = Texture2DToPNG(tex2d);
            //�ۑ�
            File.WriteAllBytes(path, bytes);
        }

        /// <summary>
        /// �I�������p�X�̉摜��image�X�v���C�g�ɕϊ��E�\������X�N���v�g
        /// </summary>
        /// <param name="path">png�̃p�X</param>
        /// <param name="image">UnityEngine.UI.Image</param>
        public static void ConvertToTextureAndLoad(string path, Image image)
        {
            //�ǂݍ���
            byte[] bytes = File.ReadAllBytes(path);
            //�摜���e�N�X�`���ɕϊ�
            Texture2D loadTexture = new Texture2D(2, 2);
            loadTexture.LoadImage(bytes);

            //�e�N�X�`�����X�v���C�g�ɕϊ�
            image.sprite = Sprite.Create(loadTexture, new Rect(0, 0, loadTexture.width, loadTexture.height), Vector2.zero);
        }

        /// <summary>
        /// RawImage��PNG�ɃG���R�[�h���郁�\�b�h
        /// </summary>
        /// <param name="_rawImage"></param>
        /// <returns></returns>
        private static byte[] RawImageToPNG(RawImage _rawImage)
        {
            byte[] bytes = TextureToPNG(_rawImage.texture);

            return bytes;
        }
        
        /// <summary>
        /// Texture��PNG�ɃG���R�[�h���郁�\�b�h
        /// </summary>
        /// <param name="tex"></param>
        /// <returns></returns>
        private static byte[] TextureToPNG(Texture tex)
        {
            Texture2D tex2d = new Texture2D(tex.width, tex.height, TextureFormat.ARGB32, false);
            RenderTexture.active = (RenderTexture)tex;

            byte[] pngBytes = Texture2DToPNG(tex2d);
            
            RenderTexture.active = null;
            Texture2D.Destroy(tex2d);

            return pngBytes;
        }

        /// <summary>
        /// Texutre2D��PNG�ɃG���R�[�h���郁�\�b�h
        /// </summary>
        /// <param name="tex2D"></param>
        /// <returns></returns>
        private static byte[] Texture2DToPNG(Texture2D tex2d)
        {
            tex2d.ReadPixels(new Rect(0, 0, tex2d.width, tex2d.height), 0, 0, false);
            tex2d.Apply(false, false);

            byte[] pngBytes = tex2d.EncodeToPNG();
            return pngBytes;
        }
    }
}