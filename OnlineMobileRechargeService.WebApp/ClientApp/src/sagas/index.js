import { all } from 'redux-saga/effects';

import auth from './auth';
import order from './order';
import feedback from './feedback';
import transaction from './transaction';

export default function* () {
  yield all([
    auth(),
    order(),
    feedback(),
    transaction(),
  ])
}