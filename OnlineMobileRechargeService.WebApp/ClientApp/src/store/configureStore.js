import createSagaMiddleware from 'redux-saga';
import { connectRouter, routerMiddleware } from 'connected-react-router';
import { applyMiddleware, combineReducers, compose, createStore } from 'redux';

import authState from '../reducers/auth';
import orderState from '../reducers/order';
import transactionState from '../reducers/transaction';

export const sagaMiddleware = createSagaMiddleware();

export default function configureStore(history, initialState) {
    const middleware = [
        sagaMiddleware,
        routerMiddleware(history)
    ];

    const rootReducer = combineReducers({
        authState,
        orderState,
        transactionState,
        router: connectRouter(history)
    });

    const enhancers = [];
    const windowIfDefined = typeof window === 'undefined' ? null : window;
    if (windowIfDefined && windowIfDefined.__REDUX_DEVTOOLS_EXTENSION__) {
        enhancers.push(windowIfDefined.__REDUX_DEVTOOLS_EXTENSION__());
    }

    return createStore(
        rootReducer,
        initialState,
        compose(applyMiddleware(...middleware), ...enhancers)
    );
}
