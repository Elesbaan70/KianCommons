namespace KianCommons.UI {
    using ColossalFramework.UI;
    using UnityEngine;

    public class UISliderExt : UISlider {
        public static UISliderExt Instance { get; private set; }

        public override void Awake() {
            base.Awake();
            Instance = this;
        }

        UISlicedSprite slicedSprite_;
        public override void Start() {
            base.Start();

            builtinKeyNavigation = true;
            isInteractive = true;
            color = Color.grey;
            name = GetType().Name;
            height = 15f;
            float padding = 0; // contianer has padding
            width = parent.width - 2 * padding;

            maxValue = 100;
            minValue = 0;
            stepSize = 1;
            AlignTo(parent, UIAlignAnchor.TopLeft);

            Log.Debug("parent:" + parent);
            slicedSprite_ = AddUIComponent<UISlicedSprite>();
            slicedSprite_.spriteName = "ScrollbarTrack";
            slicedSprite_.height = 12;
            slicedSprite_.width = width;
            slicedSprite_.relativePosition = new Vector3(padding, 2f);

            UISprite thumbSprite = AddUIComponent<UISprite>();
            thumbSprite.spriteName = "ScrollbarThumb";
            thumbSprite.height = 20f;
            thumbSprite.width = 10f;
            thumbObject = thumbSprite;
            thumbOffset = new Vector2(padding, 0);

            value = 0;

            eventSizeChanged += (component, value) => {
                // TODO [clean up] is this necessary? move it to override.
                slicedSprite_.width = slicedSprite_.parent.width - 2 * padding;
            };
        }

        protected override void OnValueChanged() {
            tooltip = value.ToString();
            RefreshTooltip();
        }

        //public virtual bool ShouldShow{get;}

        //public virtual void Refresh() {
        //    parent.isVisible = isVisible = slicedSprite_.isEnabled = thumbObject.isEnabled = isEnabled = data.CanModifyOffset();
        //    parent.Invalidate();
        //    Invalidate();
        //    thumbObject.Invalidate();
        //    slicedSprite_.Invalidate();
        //    //Log.Debug($"slider.Refresh: node:{data.NodeID} isEnabled={isEnabled}\n" + Environment.StackTrace);
        //}
    }
}
