import PropTypes from "prop-types";
import styles from './Search.module.css';
import Blackout from "../../../../components/blackout/Blackout.jsx";
import History from "./history/History.jsx";

import Cookies from 'universal-cookie';
import React, {Component} from "react";

class Search extends Component {


    state = {
        cancelingBlackoutZIndex : undefined,
    }

    constructor(props) {
        super(props);

        this.cookies = new Cookies();

        this.refHistory = React.createRef();

        this.refSearchInput = React.createRef();

        this.visBlackout = <Blackout
            background={`rgba(0, 0, 0, 0.39)`}
            setCancelingBlackoutZIndex={(zIndex) => this.setState({cancelingBlackoutZIndex : zIndex})}
            callBack={() => this.blackoutCallBack()}
            setRef={(ref) => this.blackout = ref}/>

        this.visHistory = <History  searchClick={(text) => this.searchClick(text)}  ref={this.refHistory}></History>
    }


    //Событие при котором происходит затемнение
     onFocusInput(){
         this.blackout().on();
         this.refHistory.current.onFocusInput(this.state.inputText)
    }

    //Событие при котором отменяеться затемнение
    blackoutCallBack(){
        this.refHistory.current.hideHistory();
    }

    searchClick(text = undefined){

        if(text){
            this.setState({
                inputText: text
            })
        }else{
            text = this.state.inputText;
        }


        this.refHistory.current.searchClick(text) ;

        this.refSearchInput.current.blur();

        this.blackout().off();

    }

    setInputTextState(text){
        this.setState({inputText : text})
        this.refHistory.current.setInputTextState(text);
    }

    render()
    {

        return (
            <>
                {this.visBlackout}
                <div style={{zIndex : this.state.cancelingBlackoutZIndex}} className={styles.searchContainer}>
                    <div className={styles.inputContainer}>
                        <input  ref={this.refSearchInput}
                                onChange={(event) => this.setInputTextState(event.target.value)}
                                onFocus={() => this.onFocusInput()}
                                value={this.state.inputText}
                                className={styles.input} placeholder="Найти товары"/>
                    </div>

                    <button className={styles.btnSend} onClick={() => this.searchClick()}>
                        Найти
                    </button>
                    {this.visHistory}


                </div>
            </>
        )
    }




}


Search.propTypes = {
    blackout: PropTypes.object,
    refHistory: History
};

export default Search
