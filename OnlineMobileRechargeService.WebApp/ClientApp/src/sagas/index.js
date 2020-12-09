import { all } from 'redux-saga/effects';
import auth from './auth';
import order from './order';

export default function* () {
  yield all([
    auth(),
    order(),
  ])
}