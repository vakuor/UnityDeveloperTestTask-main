using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class CardView : MonoBehaviour
    {
        [SerializeField] private Image _background;
        [SerializeField] private Image _galaxyImage;
        [SerializeField] private Image _mainImage;
        [SerializeField] private CardTitleView _titleView;
        [SerializeField] private Image _disableImage;
    
        public PlayButton PlayButton;

        [SerializeField] private ProgressView _progressView;

        private bool _disabled = false;

        public void Initialize(Card card)
        {
            name = card.name + " Card";
            _background.sprite = card.Background;
            _galaxyImage.sprite = card.GalaxyImage;
            _mainImage.sprite = card.MainImage;
            _titleView.Initialize(card.Name);
            _disableImage.sprite = card.DisableImage;
            _disabled = card.Disabled;
            PlayButton.Initialize(card);
            _progressView.Initialize(card.ProgressData);
        
            //FixImageSize(_titleImage, card.TitleImage);
            //FixImageSize(_mainImage, card.MainImage);
            Disable(_disabled);
        

        }

        private void FixImageSize(Image image, Sprite targetImage)
        {
            var imageRect = image.rectTransform;
            var newSize = targetImage.rect.size;
            imageRect.sizeDelta = newSize;
        }

        private void Disable(bool disabled)
        {
            _disableImage.gameObject.SetActive(disabled);
            PlayButton.gameObject.SetActive(!disabled);
        
        }

        public void MakeEnabled()
        {
            _disabled = false;
            _disableImage.gameObject.SetActive(false);

        }
        public void MakeDisabled()
        {
            _disabled = true;
            _disableImage.gameObject.SetActive(true);

        }
    }
}
