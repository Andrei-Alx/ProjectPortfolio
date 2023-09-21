import React from 'react';
import Slider from 'react-slick';
import 'slick-carousel/slick/slick.css'
import 'slick-carousel/slick/slick-theme.css'
import "./Carousel.css"

const ImageCarousel = ({ images }) => {
const settings = {
    dots: true,
    infinite: true,
    speed: 500,
    slidesToShow: 3,
    slidesToScroll: 1,
    autoplay: true,
    arrows: false,
    centerMode: true,
    variableWidth: true,
    
};

return (
        <Slider {...settings}>
        {images.map((image, index) => (
            <div key={index}>
            <img src={image} alt={`Slide ${index}`} />
            </div>
        ))}
        </Slider>
);
};

export default ImageCarousel;