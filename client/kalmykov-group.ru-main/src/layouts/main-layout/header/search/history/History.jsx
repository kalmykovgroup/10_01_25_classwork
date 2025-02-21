import styles from './History.module.css';

import Cookies from "universal-cookie";
import {Component} from "react";
import PropTypes from "prop-types";

class History extends Component {

    cookieHistoryKey = "history";

    state = {
        history : [],
        isOpenHistory : false
    }
    constructor(props) {
        super(props);

        this.cookies = new Cookies();
        this.state = ({history : this.cookies.get(this.cookieHistoryKey) ?? []});
    }

    //Событие при котором происходит затемнение
    onFocusInput(inputText){

        if(this.state.history.length > 0){
            this.setState({
                inputText : inputText,
                isOpenHistory : true
            })
        }
    }

    //Событие при котором отменяеться затемнение
    hideHistory(){
        if(this.state.isOpenHistory){
            this.setState({
                isOpenHistory : false
            })
        }
    }

    searchClick(text){
        const history = this.cookies.get(this.cookieHistoryKey);

        if(!history){
            this.cookies.set(this.cookieHistoryKey, [text]);
        }else{
            const newHistory = [text];

            for(let i = 0; i < history.length; ++i){
                if(history[i] === text) continue;
                newHistory.push(history[i]);
            }
            this.cookies.set(this.cookieHistoryKey, newHistory);
            this.setState({history : history})
        }
        this.setState({
            isOpenHistory : false
        });
    }


    clickHistory(text){
        this.setState({
            isOpenHistory : false
        });

        this.props.searchClick(text)
    }

    deleteHistory(item){ 
        const history = this.cookies.get(this.cookieHistoryKey);

        const newHistory = history.filter((j) => j !== item);

        this.cookies.set(this.cookieHistoryKey, newHistory);

        this.setState({history : newHistory})
    }

    setInputTextState(text){
        this.setState({inputText : text})
    }

    render()
    {
        let history = undefined;
        if(this.state.isOpenHistory && this.state.history.length > 0){
            history = this.generateHistoryItems();
        }

        return (
            <>
                <div style={{display: !(history && history.length > 0) ? "none" : undefined}}
                     className={styles.historyContainer}>

                    <div className={styles.history}>
                        <ul>
                            {history}
                        </ul>
                    </div>

                </div>
            </>
        )
    }

    getObjects(){
        const objects = [];

        const textInput = this.state.inputText?.trim();

        if(textInput === "" || textInput === undefined){
            for(let i = 0; i < this.state.history.length && i < 10; ++i){
                objects.push(
                    {
                        value : this.state.history[i],
                        html : this.state.history[i],
                    }
                );
            }
        }else{
            for(let i = 0; i < this.state.history.length; ++i){
                let idx = this.state.history[i].indexOf(textInput);

                if(idx !== -1){

                    const html = (
                        <>
                            {this.state.history[i].slice(0, idx)}
                            <b>
                                {this.state.history[i].slice(idx, idx + textInput.length)}
                            </b>
                            {this.state.history[i].slice(idx + textInput.length)}
                        </>
                    );
                    objects.push(
                        {
                            position: idx,
                            html : html,
                            value : this.state.history[i],
                        });
                }
            }

            objects.sort((a, b) => a.position - b.position);

        }
        return objects;

    }

    generateHistoryItems(){

        const objects = this.getObjects();
        const list = [];

        for(let i = 0; i < objects.length && i < 10; ++i){
            list.push(
                <li key={i} className={styles.item}>
                    <div className={`${styles.text}`}  onClick={() => this.clickHistory(objects[i].value)}>
                        <span>{objects[i].html}</span>
                    </div>
                    <span className={styles.btnDeleteHistory} onClick={() => this.deleteHistory(objects[i].value)}>
                                         <svg width='12' height='12' xmlns='http://www.w3.org/2000/svg'>
                                             <path d='m6.594 5.887 5.18 5.18-.707.707-5.18-5.18-5.18 5.18L0 11.067l5.18-5.18L0 .707.707 0l5.18 5.18L11.067 0l.707.707-5.18 5.18Z'/>
                                         </svg>
                                    </span>

                </li>
            )
        }

        return list;
    }

}
History.propTypes = {
    searchClick: PropTypes.func,
};


export default History
