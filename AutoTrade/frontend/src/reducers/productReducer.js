import { PRODUCT_LIST } from "../constants/actionTypes";

const initialState ={
    list: []
}

const productReducer = (state = initialState, action) => {
    const {type, payload} = action;
    switch(type) {
        case PRODUCT_LIST: {
            return {
                ...state,
                list: payload
            };
        } 
        default: {
            return state;
        }
    }


}

export default productReducer; 