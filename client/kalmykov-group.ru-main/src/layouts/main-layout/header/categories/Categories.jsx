import styles from './Categories.module.css';
import {Component} from "react";
import PropTypes from "prop-types";

import arrowIcon from '/src/assets/category/arrow.svg'

import {Link} from "react-router-dom";

class Categories extends Component{

    constructor(props) {
        super(props);
        this.state ={
            activeCategory : undefined,
            categoryOpenId : undefined,
            categories : [
                {
                    id : 1,
                    name : "Одежда и обувь",
                    img : "home.svg",
                    categories : [
                        {
                            id : 4,
                            name : "Женщинам",
                            categories : [
                                { id : 7, name : "Аксессуары"},
                                { id : 8, name : "Блузы и рубашки"},
                                { id : 9, name : "Боди"},
                                { id : 10, name : "Брюки"},
                                { id : 11, name : "Верхняя одежда"},
                                { id : 12, name : "Водолазки"},
                                { id : 13, name : "Джемперы, свитеры, кардиганы"},
                                { id : 14, name : "Джинсы"},
                                { id : 15, name : "Домашняя одежда"},
                            ]
                        },
                        {
                            id : 5,
                            name : "Мужчинам",
                            categories : [
                                { id : 16, name : "Аксессуары"},
                                { id : 17, name : "Блузы и рубашки"},
                                { id : 18, name : "Боди"},
                                { id : 19, name : "Брюки"},
                                { id : 20, name : "Верхняя одежда"},
                                { id : 21, name : "Водолазки"},
                                { id : 22, name : "Джемперы, свитеры, кардиганы"},
                                { id : 23, name : "Джинсы"},
                                { id : 24, name : "Домашняя одежда"},
                            ]
                        },
                        {
                            id : 6,
                            name : "Детям",
                            categories : [
                                { id : 16, name : "Аксессуары"},
                                { id : 17, name : "Блузы и рубашки"},
                                { id : 18, name : "Боди"},
                                { id : 19, name : "Брюки"},
                                { id : 20, name : "Верхняя одежда"},
                                { id : 21, name : "Водолазки"},
                                { id : 22, name : "Джемперы, свитеры, кардиганы"},
                                { id : 23, name : "Джинсы"},
                                { id : 24, name : "Домашняя одежда"},
                            ]
                        },
                        {
                            id : 25,
                            name : "Обувь",
                            categories : [
                                { id : 16, name : "Мужская"},
                                { id : 17, name : "Женская"},
                            ]
                        },
                        {
                            id : 26,
                            name : "Аксессуары",
                            categories : [
                                { id : 16, name : "Сумки, рюкзаки, чемоданы"},
                            ]
                        },
                        {
                            id : 27,
                            name : "Ресейл",
                            categories : [

                            ]
                        }
                    ]
                },
                {
                    id : 2,
                    name : "Дом",
                    img : "clothes.svg",
                    categories : [

                    ]
                },
                {
                    id : 3,
                    name : "Детские товары",
                    img : "childrenProducts.svg",
                    categories : [

                    ]
                }
            ]
        }
    }

    render() {

        const listItems = this.state.categories.map(category =>
            <li key={category.id}
                className={`${styles.categoryItem} ${category.id === this.state.activeCategory?.id ? styles.active : ""}`}
                onMouseEnter={() => this.setState({
                    activeCategory: category,
                    categoryOpenId : undefined
                })}>
                <img src={`/src/assets/category/${category.img}`} className={`${styles.icon}`} alt=""/>
                <span className={styles.name}>{category.name}</span>
                <img src={arrowIcon} className={`${styles.arrowIcon}`} alt=""/>
            </li>
        );


        return (
            <div className={styles.container}>


                <div className={styles.categories}>
                        <ul className={styles.leftCategoryMenu}>
                            {listItems}
                        </ul>
                        <div className={styles.rightCategoryContainer}>
                            <div>
                                <Link  className={`${styles.bigTitle}`}  to={`/categories`}>
                                    {this.state.activeCategory?.name}
                                </Link>
                            </div>
                            <div>

                                <div className={styles.categoryContainer}>
                                    {/*нужно отобразить категории сеткой, но в три столбца. Таким образом мы помещаем каждый третюю категорию.
                                    0,1,2 - Это отступ для цыкла, который берет каждую 3 запись*/}
                                    <div className={styles.wrapper}>{this.showCategoriesCategoryActive(0)}</div>
                                    <div className={styles.wrapper}>{this.showCategoriesCategoryActive(1)}</div>
                                    <div className={styles.wrapper}>{this.showCategoriesCategoryActive(2)}</div>

                                </div>
                            </div>
                        </div>

                 </div>
           </div>
        );
    }

    showCategoriesCategoryActive(coll){
        const list = [];


        for(let i = coll; i < this.state.activeCategory?.categories.length; i += 3){
            list.push(
                <div key={this.state.activeCategory.categories[i].id} className={styles.categoryDownList}>

                    <Link className={`${styles.titleOneSunCategory}`} to={`/categories`}>{this.state.activeCategory.categories[i].name}</Link>

                    <ul>
                        {this.showRecentSubCategories(this.state.activeCategory.categories[i])}


                    </ul>

                </div>
            );
        }

        return ( <> {list} </> );
    }



    showRecentSubCategories(category){

        const list = [];
        const isOpen = this.state[`${category.id}`] ?? false;

        for(let i = 0; i < category.categories.length && (i < 5 || isOpen); ++i){
            list.push(
                <li key={category.categories[i].id}>
                    <Link className={`${styles.titleTwoSunCategory}`} to={`/categories`}>{category.categories[i].name}</Link>
                </li>
            );
        }

        return (
            <>
                {list}
                {this.toggleButtonRollUp(category)}
            </>

        );
    }

    toggleButtonRollUp(category) {
        return (
            category.categories.length > 5 &&
            <button onClick={() => {

                if(this.state[`${category.id}`]){
                    this.setState({[`${category.id}`] : false });
                }else{
                    this.setState({[`${category.id}`] : true });
                }

            }}>
                {this.state[`${category.id}`]
                    ?
                    <div className={styles.toggleButtonRollDown}>
                        <span>Свернуть</span>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 20 20">
                            <path d="m10 8.871 4.094 4.094 1.062-1.059L10 6.75l-5.154 5.154 1.06 1.061L10 8.871z">
                            </path>
                        </svg>
                    </div>
                    :
                    <div className={styles.toggleButtonRollUp}>
                        <span>Еще</span>
                        <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24">
                            <path d="M19.997 10.007 12 18.004l-7.997-7.997 1.414-1.414L12 15.176l6.583-6.583z">
                            </path>
                        </svg>
                    </div>
                }
            </button>
        );
    }
}


Categories.propTypes = {
    isOpen: PropTypes.bool
};


export default Categories
