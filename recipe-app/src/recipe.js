import React from "react";
import style from "./recipe.module.css"

const Recipe = ({title,calories,image,ingredients}) => {
    return (
        <div className={style.recipe}>
            <h1>{title}</h1>
            <p>Total calories :- {calories}</p>
            <ul>
                {ingredients.map(ingredient => (
                    <li>{ingredient.text}</li>
                ))}
            </ul>
            <img className={style.image} src={image} alt={title}></img>
        </div>
    );
}

export default Recipe;