import React from "react"
import ImageCarousel from "../components/Carousel/Carousel";

function HomePage(){
const images = [
    'https://i.imgur.com/8ckkWri.jpg',
    'https://i.imgur.com/mxQkT2n.jpg',
    'https://i.imgur.com/z9QIxGO.jpg',
    'https://i.imgur.com/BM2yMLj.jpg',
    'https://i.imgur.com/3mTVoqg.jpg',
];

    return ( <div>
                <h1>Welcome to The Grand Slam Chronicles</h1>
                <img src="https://i.imgur.com/nF9dzBy.png" alt="The Grand Slam Chronicles logo"></img>
                <ImageCarousel images={images}/>
            </div> )
}

export default HomePage;