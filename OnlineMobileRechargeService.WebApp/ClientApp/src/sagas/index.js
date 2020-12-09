import { all } from 'redux-saga/effects';
import auth from './auth';
import order from './order';
import transaction from './transaction';

export default function* () {
  yield all([
    auth(),
    order(),
    transaction(),
  ])
}