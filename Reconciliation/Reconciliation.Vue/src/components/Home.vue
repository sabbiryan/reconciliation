<template>
  <div class="container">
    <h4 class="text-center mt-5">We are in vue app</h4>
    <h1 class="text-center mt-5" v-if="!grid">Loading...</h1>

    <div class="row">
      <div class="col-12" v-if="grid">
        <table class="table table-striped table-bordered">
          <thead>
            <tr class="text-center">
              <th colspan="14">Year {{grid.year}}</th>
            </tr>
            <tr class="text-center">
              <th></th>
              <th v-for="title in grid.titles" :key="title.month">{{title.monthDisplayName}}</th>
            </tr>
          </thead>
          <tbody>
            <tr v-for="row in grid.statements" :key="row.month" class="table-secondary">
              <td>{{row.title}}</td>
              <td v-for="col in row.values" :key="col.month">{{col.amount}}</td>
            </tr>

            <tr
              v-for="(row, rowIndex) in grid.rows"
              :key="row.month"
              v-bind:class="{ 'table-success': row.flag==1, 'table-danger': row.flag==2, }"
            >
              <td>{{row.incomeOrExpenseTypeName}}</td>

              <td
                v-for="(col, colIndex) in row.columns"
                :key="col.month"
                @click="editCell(rowIndex, colIndex)"
              >
                <span
                  v-if="!isEditing || isEditing && (editingRowIndex!=rowIndex || editingColIndex!=colIndex)"
                  class="pointer"
                >{{col.amount}}</span>

                <span v-if="isEditing && editingRowIndex==rowIndex && editingColIndex==colIndex">
                  <input
                    class="input-size"
                    autofocus
                    autocomplete="off"
                    placeholder="Amount"
                    v-model="col.amount"
                    @keyup.enter="update(col)"
                    @blur="clearCell()"
                  />
                </span>
              </td>
            </tr>

            <tr v-for="row in grid.results" :key="row.month" class="table-secondary">
              <td>{{row.title}}</td>
              <td v-for="col in row.values" :key="col.month">{{col.amount}}</td>
            </tr>
          </tbody>
        </table>

        <div class="row mb-5">
          <div class="col-12 text-center">
            <span class="badge badge-secondary">Readonly</span>
            &nbsp;&nbsp;
            <span class="badge badge-success">Income</span>
            &nbsp;&nbsp;
            <span class="badge badge-danger">Expense</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script lang="ts">
import { Component, Prop, Vue } from "vue-property-decorator";
import {
  YearlyReconciliationGridDto,
  YearlyReconciliationGridColumnDto
} from "../models/dtos/yearly-reconsiliation-grid-dto.model";
import Axios, { AxiosResponse } from "axios";

@Component
export default class Home extends Vue {
  public grid: YearlyReconciliationGridDto | undefined;
  @Prop() private isEditing: boolean | undefined;
  public editingRowIndex: number | undefined;
  public editingColIndex: number | undefined;

  constructor() {
    super();
    this.grid = new YearlyReconciliationGridDto();
    this.getAll();
  }

  getAll() {
    Vue.axios
      .get<YearlyReconciliationGridDto>(
        "http://localhost:49660/reconciliation/yearly-table"
      )
      .then(response => {
        this.grid = response.data;
      });
  }

  editCell(rowIndex: number, colIndex: number) {
    this.isEditing = true;
    this.editingRowIndex = rowIndex;
    this.editingColIndex = colIndex;
  }

  clearCell() {
    this.isEditing = false;
    this.editingRowIndex = undefined;
    this.editingColIndex = undefined;
  }

  update(item: YearlyReconciliationGridColumnDto) {
    Vue.axios
      .put("http://localhost:49660/reconciliation", item)
      .then(response => {
        this.getAll();
        this.clearCell();
      });
  }
}
</script>

<style scoped>
.pointer {
  cursor: pointer;
  width: 100%;
  display: block;
}

.input-size {
  width: 80px !important;
}
</style>
